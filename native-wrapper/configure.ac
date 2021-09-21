# Process this file with autoconf to produce a configure script.

AC_PREREQ([2.69])
AC_INIT([net-keytar], [0.1], [berdon.net-keytar@gmail.com])
AM_INIT_AUTOMAKE([foreign])

AC_CANONICAL_HOST
AS_CASE([$host_cpu], [i?86], [ARCH=i386], [x86_64], [ARCH="x86_64"], [arm*], [ARCH="arm"])
AS_CASE([$host_os], [linux*], [OS=linux], [darwin*], [OS=darwin])

AM_CONDITIONAL([ARCH_I386], [test "$ARCH" = "i386"])
AM_CONDITIONAL([ARCH_X86_64], [test "$ARCH" = "x86_64"])
AM_CONDITIONAL([ARCH_ARM], [test "$ARCH" = "arm"])
AM_CONDITIONAL([ARCH_UNDEFINED], [test "x$ARCH" = "x"])

AM_CONDITIONAL([OS_LINUX], [test "$OS" = "linux"])
AM_CONDITIONAL([OS_DARWIN], [test "$OS" = "darwin"])
AM_CONDITIONAL([OS_UNDEFINED], [test "x$OS" = "x"])

# Checks for programs.
AC_PROG_CXX
AC_ENABLE_SHARED
AC_DISABLE_STATIC
LT_INIT

# Checks for libraries.

# Checks for header files.

# Checks for typedefs, structures, and compiler characteristics.

# Checks for library functions.

AC_CONFIG_FILES([Makefile])
AC_OUTPUT