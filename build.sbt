ThisBuild / version := "1.0.0"
ThisBuild / scalaVersion := "3.3.1"
ThisBuild / organization := "ragazoor.aoc"
val dependencies = Seq(
  "dev.zio" %% "zio" % "2.0.19",
  "dev.zio" %% "zio-test" % "2.0.19" % Test,
  "dev.zio" %% "zio-test-sbt" % "2.0.19" % Test,
  "dev.zio" %% "zio-test-magnolia" % "2.0.19" % Test,
  "dev.zio" %% "zio-mock" % "1.0.0-RC11"
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
    libraryDependencies ++= dependencies,
    testFrameworks += new TestFramework("zio.test.sbt.ZTestFramework")
  )
