package ragazoor.aoc.day1

import zio.*

import scala.util.Using
import scala.io.Source
import java.nio.file.Path
import scala.util.Try

object InputRepoImpl
    extends InputRepo:
    def getPart1: Try[Seq[String]] = 
        Using(openInputFile("part1"))(file2Lines)

    private def openInputFile(fileName: String): Source = 
        val inputPath = Path.of(s"/$fileName.txt")
        val inputStream = getClass.getResourceAsStream(inputPath.toString)
        if (inputStream == null)
            throw new NullPointerException(s"Could not find input file: $inputPath")
        else
            Source.fromInputStream(inputStream)

    private def file2Lines(userSource: Source): Seq[String] = 
        userSource.getLines.toSeq