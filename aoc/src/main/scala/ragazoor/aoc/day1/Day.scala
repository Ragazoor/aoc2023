package ragazoor.aoc.day1

import zio.*

trait Day {
  def part1: Task[Unit]
  def part2: Task[Unit]
}

object Day {
  def part1: RIO[Day, Unit] =
    ZIO.serviceWithZIO(_.part1)
}
