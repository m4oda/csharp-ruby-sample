# csharp-ruby-sample

C#（.NET Core）から Ruby を呼び出すサンプルを調べながら書いてみました。
このリポジトリには、次のサンプルがあります:

1. hello
  * プログラムに埋め込まれている文字列を Ruby スクリプトとして実行します。
1. runner
  * 外部に配置された Ruby スクリプトのファイルを読み込んで実行します。
  * 単にファイルを全部読み込んで実行しているだけなので、実質的に hello と同じです。
1. func
  * 外部に配置された Ruby スクリプトのファイルを読み込みます。
  * 読み込んだファイルに記述されているクラスからインスタンスを作成します。
  * 作成したインスタンスのメソッドを実行します。
  * 実行したメソッドの戻り値を表示します。

Linux 環境で実行するには `libruby.so` が必要です。
`libruby.so` がそれぞれのプロジェクトの `lib` ディレクトリに配置（コピー）されているという前提で書いてあります。
