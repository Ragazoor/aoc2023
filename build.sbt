ThisBuild / version := "1.0.0"
ThisBuild / scalaVersion := "3.3.1"
ThisBuild / organization := "ragazoor.aoc"
val dependencies = Seq(
 "org.scalatest" %% "scalatest" % "3.1.0" % Test
)

lazy val root = project
  .in(file("."))
  .aggregate(
    aoc
  )

lazy val aoc = project
  .in(file("aoc"))
  .settings(
    name := "aoc",
    libraryDependencies ++= dependencies
  )

