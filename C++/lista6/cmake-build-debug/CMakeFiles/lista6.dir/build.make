# CMAKE generated file: DO NOT EDIT!
# Generated by "MinGW Makefiles" Generator, CMake Version 3.13

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Remove some rules from gmake that .SUFFIXES does not remove.
SUFFIXES =

.SUFFIXES: .hpux_make_needs_suffix_list


# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = D:\JetBrains\apps\CLion\ch-0\183.5429.37\bin\cmake\win\bin\cmake.exe

# The command to remove a file.
RM = D:\JetBrains\apps\CLion\ch-0\183.5429.37\bin\cmake\win\bin\cmake.exe -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = D:\STUDIA\C++\lista6

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = D:\STUDIA\C++\lista6\cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/lista6.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/lista6.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/lista6.dir/flags.make

CMakeFiles/lista6.dir/main.cpp.obj: CMakeFiles/lista6.dir/flags.make
CMakeFiles/lista6.dir/main.cpp.obj: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=D:\STUDIA\C++\lista6\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/lista6.dir/main.cpp.obj"
	C:\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles\lista6.dir\main.cpp.obj -c D:\STUDIA\C++\lista6\main.cpp

CMakeFiles/lista6.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lista6.dir/main.cpp.i"
	C:\MinGW\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E D:\STUDIA\C++\lista6\main.cpp > CMakeFiles\lista6.dir\main.cpp.i

CMakeFiles/lista6.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lista6.dir/main.cpp.s"
	C:\MinGW\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S D:\STUDIA\C++\lista6\main.cpp -o CMakeFiles\lista6.dir\main.cpp.s

CMakeFiles/lista6.dir/zmienna.cpp.obj: CMakeFiles/lista6.dir/flags.make
CMakeFiles/lista6.dir/zmienna.cpp.obj: ../zmienna.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=D:\STUDIA\C++\lista6\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/lista6.dir/zmienna.cpp.obj"
	C:\MinGW\bin\g++.exe  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles\lista6.dir\zmienna.cpp.obj -c D:\STUDIA\C++\lista6\zmienna.cpp

CMakeFiles/lista6.dir/zmienna.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lista6.dir/zmienna.cpp.i"
	C:\MinGW\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E D:\STUDIA\C++\lista6\zmienna.cpp > CMakeFiles\lista6.dir\zmienna.cpp.i

CMakeFiles/lista6.dir/zmienna.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lista6.dir/zmienna.cpp.s"
	C:\MinGW\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S D:\STUDIA\C++\lista6\zmienna.cpp -o CMakeFiles\lista6.dir\zmienna.cpp.s

# Object files for target lista6
lista6_OBJECTS = \
"CMakeFiles/lista6.dir/main.cpp.obj" \
"CMakeFiles/lista6.dir/zmienna.cpp.obj"

# External object files for target lista6
lista6_EXTERNAL_OBJECTS =

lista6.exe: CMakeFiles/lista6.dir/main.cpp.obj
lista6.exe: CMakeFiles/lista6.dir/zmienna.cpp.obj
lista6.exe: CMakeFiles/lista6.dir/build.make
lista6.exe: CMakeFiles/lista6.dir/linklibs.rsp
lista6.exe: CMakeFiles/lista6.dir/objects1.rsp
lista6.exe: CMakeFiles/lista6.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=D:\STUDIA\C++\lista6\cmake-build-debug\CMakeFiles --progress-num=$(CMAKE_PROGRESS_3) "Linking CXX executable lista6.exe"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\lista6.dir\link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/lista6.dir/build: lista6.exe

.PHONY : CMakeFiles/lista6.dir/build

CMakeFiles/lista6.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles\lista6.dir\cmake_clean.cmake
.PHONY : CMakeFiles/lista6.dir/clean

CMakeFiles/lista6.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" D:\STUDIA\C++\lista6 D:\STUDIA\C++\lista6 D:\STUDIA\C++\lista6\cmake-build-debug D:\STUDIA\C++\lista6\cmake-build-debug D:\STUDIA\C++\lista6\cmake-build-debug\CMakeFiles\lista6.dir\DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/lista6.dir/depend

