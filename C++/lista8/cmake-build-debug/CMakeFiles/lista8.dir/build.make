# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.14

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

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /home/szipi/.local/share/JetBrains/Toolbox/apps/CLion/ch-0/191.6707.69/bin/cmake/linux/bin/cmake

# The command to remove a file.
RM = /home/szipi/.local/share/JetBrains/Toolbox/apps/CLion/ch-0/191.6707.69/bin/cmake/linux/bin/cmake -E remove -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /mnt/01CE8F7A5089BFF0/Studia/C++/lista8

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug

# Include any dependencies generated for this target.
include CMakeFiles/lista8.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/lista8.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/lista8.dir/flags.make

CMakeFiles/lista8.dir/main.cpp.o: CMakeFiles/lista8.dir/flags.make
CMakeFiles/lista8.dir/main.cpp.o: ../main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/lista8.dir/main.cpp.o"
	/usr/bin/c++  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles/lista8.dir/main.cpp.o -c /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/main.cpp

CMakeFiles/lista8.dir/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/lista8.dir/main.cpp.i"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/main.cpp > CMakeFiles/lista8.dir/main.cpp.i

CMakeFiles/lista8.dir/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/lista8.dir/main.cpp.s"
	/usr/bin/c++ $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/main.cpp -o CMakeFiles/lista8.dir/main.cpp.s

# Object files for target lista8
lista8_OBJECTS = \
"CMakeFiles/lista8.dir/main.cpp.o"

# External object files for target lista8
lista8_EXTERNAL_OBJECTS =

lista8: CMakeFiles/lista8.dir/main.cpp.o
lista8: CMakeFiles/lista8.dir/build.make
lista8: CMakeFiles/lista8.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking CXX executable lista8"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/lista8.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/lista8.dir/build: lista8

.PHONY : CMakeFiles/lista8.dir/build

CMakeFiles/lista8.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles/lista8.dir/cmake_clean.cmake
.PHONY : CMakeFiles/lista8.dir/clean

CMakeFiles/lista8.dir/depend:
	cd /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /mnt/01CE8F7A5089BFF0/Studia/C++/lista8 /mnt/01CE8F7A5089BFF0/Studia/C++/lista8 /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug /mnt/01CE8F7A5089BFF0/Studia/C++/lista8/cmake-build-debug/CMakeFiles/lista8.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : CMakeFiles/lista8.dir/depend

