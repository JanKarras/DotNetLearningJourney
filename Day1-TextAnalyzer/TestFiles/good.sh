#!/bin/bash

GREEN="\033[0;32m"
RED="\033[0;31m"
NC="\033[0m"

PROJECT_ROOT=".."
PROGRAM="dotnet run --no-build"

GOOD_DIR="good"

echo -e "${GREEN}Running GOOD file tests...${NC}"
echo "----------------------------------"

TOTAL=0
PASSED=0

for file in "$GOOD_DIR"/*.txt; do
	((TOTAL++))
	echo -e "\n👉 Testing file: $file"

	INPUT_PATH="TestFiles/$file"

	OUTPUT=$(cd "$PROJECT_ROOT" && $PROGRAM "$INPUT_PATH" 2>&1)
	EXIT_CODE=$?

	if [[ $EXIT_CODE -ne 0 ]]; then
		echo -e "${RED}❌ FAILED (Exit code $EXIT_CODE)${NC}"
		echo "$OUTPUT"
	else
		echo -e "${GREEN}✅ PASSED${NC}"
		echo "$OUTPUT"
		((PASSED++))
	fi
done

echo -e "\n----------------------------------"
echo -e "Tests passed: ${GREEN}$PASSED/$TOTAL${NC}"
echo "----------------------------------"