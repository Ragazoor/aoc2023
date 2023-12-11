package ragazoor.aoc.day1


class Day1Test extends AnyFunSuite with MockFactory:

    test("testPart1") {
        val inputRepo = mock[InputRepo]
        val actual = Day1.getPart1(input)
        assert(expected == actual)
    }
