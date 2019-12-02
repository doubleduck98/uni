#include "csapp.h"

static pid_t spawn(void (*fn)(void))
{
  pid_t pid = Fork();
  if (pid == 0)
  {
    fn();
    printf("(%d) I'm done!\n", getpid());
    exit(EXIT_SUCCESS);
  }
  return pid;
}

static void sigint_handler() {
  safe_printf("zabili mnie :^(\n");
  return;
}

static void grandchild(void)
{
  printf("(%d) Waiting for signal!\n", getpid());
  signal(SIGINT, sigint_handler);
  pause();
  printf("(%d) Got the signal!\n", getpid());
}

static void child(void)
{
  Setpgid(getpid(), getpid());
  pid_t pid;
  pid = spawn(grandchild);
  printf("(%d) Grandchild (%d) spawned!\n", getpid(), pid);
}

/* Runs command "ps -o pid,ppid,pgrp,stat,cmd" using execve(2). */
static void ps(void)
{
  char *args[] = {"/bin/ps", "-o", "pid,ppid,pgrp,stat,cmd", NULL};
  execve(args[0], args, __environ);
}

int main(void)
{
  /* set yourself a reaper */
  Prctl(PR_SET_CHILD_SUBREAPER, 1);
  printf("(%d) I'm a reaper now!\n", getpid());

  pid_t pid, pgrp;
  int status;

  pgrp = spawn(child);
  Waitpid(pgrp, NULL, 0);

  pid = spawn(ps);
  Waitpid(pid, NULL, 0);

  Kill(-pgrp, SIGINT);
  printf("zabijam grupe %d\n", pgrp);
  Waitpid(-1, &status, 0);

  pid = spawn(ps);
  Waitpid(pid, NULL, 0);

  printf("exit code wnuka: %d\n", status);
  
  return EXIT_SUCCESS;
}
