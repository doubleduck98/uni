#include "shell.h"

typedef int (*func_t)(char **argv);

typedef struct {
  const char *name;
  func_t func;
} command_t;

static int do_quit(char **argv) {
  exit(EXIT_SUCCESS);
}

/*
 * 'cd' - change directory to $HOME
 * 'cd path' - change directory to path
 */
static int do_chdir(char **argv) {
  char *path = argv[0];
  if (path == NULL)
    path = getenv("HOME");
  int rc = chdir(path);
  if (rc < 0) {
    msg("cd: %s: %s\n", strerror(errno), path);
    return 1;
  }
  return 0;
}

static command_t builtins[] = {
  {"quit", do_quit},
  {"cd", do_chdir},
  {NULL, NULL},
};

int builtin_command(char **argv) {
  for (command_t *cmd = builtins; cmd->name; cmd++) {
    if (strcmp(argv[0], cmd->name))
      continue;
    return cmd->func(&argv[1]);
  }

  errno = ENOENT;
  return -1;
}

noreturn void external_command(char **argv) {
  const char *path = getenv("PATH");
  
  if (!index(argv[0], '/') && path) {
    char *path_iter = strdup(path);
    char *path_dup = path_iter;
    size_t path_len = strlen(path_iter);
    size_t colon_pos;
    
    while(path_len > 0) {
      colon_pos = strcspn(path_iter, ":");
      char *path_part = strndup(path_iter, colon_pos);
      strapp(&path_part, "/");
      strapp(&path_part, argv[0]);
      (void)execve(path_part, argv, environ);
      path_iter += colon_pos;
      if (strlen(path_iter) > 0)
        path_iter++;
      path_len = strlen(path_iter);
      free(path_part);
    }
    free(path_dup);
    
  } else {
    (void)execve(argv[0], argv, environ);
  }

  msg("%s: %s\n", argv[0], strerror(errno));
  exit(EXIT_FAILURE);
}
