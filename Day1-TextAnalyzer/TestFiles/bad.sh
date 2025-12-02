#!/bin/bash

GREEN="\033[0;32m"
RED="\033[0;31m"
NC="\033[0m"

PROJECT_ROOT=".."
PROGRAM="dotnet run --no-build"

echo -e "${RED}Running BAD file tests...${NC}"
echo "----------------------------------"

TOTAL=0
PASSED=0

run_test() {
	local name="$1"
	local arg="$2"
	local should_fail="$3"

	((TOTAL++))
	echo -e "\n👉 Test: $name"

	if [[ -z "$arg" ]]; then
		OUTPUT=$(cd "$PROJECT_ROOT" && $PROGRAM 2>&1)
	else
		OUTPUT=$(cd "$PROJECT_ROOT" && $PROGRAM "$arg" 2>&1)
	fi
	EXIT_CODE=$?

	if [[ "$should_fail" == "yes" && $EXIT_CODE -ne 0 ]]; then
		echo -e "${GREEN}✅ EXPECTED FAILURE (exit $EXIT_CODE)${NC}"
		echo "$OUTPUT"
		((PASSED++))
	else
		echo -e "${RED}❌ UNEXPECTED RESULT (exit $EXIT_CODE)${NC}"
		echo "$OUTPUT"
	fi
}

run_test "No arguments" "" "yes"

run_test "Non-existent file" "TestFiles/bad/does_not_exist.txt" "yes"

run_test "Directory instead of file" "TestFiles/bad/dir_as_file" "yes"

run_test "File without read permission" "TestFiles/bad/no_read.txt" "yes"

run_test "Wrong extension (.log)" "TestFiles/bad/wrong_ext.log" "yes"

run_test "Empty file" "TestFiles/bad/empty.txt" "yes"

run_test "Only separators" "TestFiles/bad/only_separators.txt" "yes"

echo -e "\n----------------------------------"
echo -e "BAD tests passed: ${GREEN}$PASSED/$TOTAL${NC}"
echo "----------------------------------"
