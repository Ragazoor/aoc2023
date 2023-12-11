package ragazoor.aoc.day1


class Day1(inputRepo: InputRepo):
    def part1: Unit =
        for {
            input <- inputRepo.getPart1
            result = getPart1(input)
            _ = println(result)
        } yield ()

    private def getPart1(input: Seq[String]): Seq[Int] =
        input.map{ line => 
            val numbers = line.toCharArray.filter(_.isDigit)
            val firstNum = numbers.head.toString.toInt
            val lastNum = numbers.last.toString.toInt
            firstNum + lastNum
        }

