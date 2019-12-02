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
    /* TODO: For all paths in PATH construct an absolute path and execve it. */
    char* dup = strdup(path);
    char* new_path = dup;
    int dlug_path = strlen(new_path);
    size_t duwkropek = 0;
    while(dlug_path > 0) {
      duwkropek = strcspn(new_path, ":");
      char *prog = strndup(new_path, duwkropek);
      strapp(&prog, "/");
      strapp(&prog, argv[0]);
      (void)execve(prog, argv, environ);
      new_path = new_path + duwkropek;
      if(strlen(new_path) > 0) new_path += 1;
      dlug_path = strlen(new_path);
      free(prog);
    }
    free(dup);
    // free new path pls
  } else {
    (void)execve(argv[0], argv, environ);
  }

  msg("%s: %s\n", argv[0], strerror(errno));
  exit(EXIT_FAILURE);
}
