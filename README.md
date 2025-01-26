# 簡易カーニング-YMM4プラグイン
## 概要
テキストの描画位置や拡大率などを文字ごとに調整する映像エフェクトプラグインです。  
## 導入方法
[Releases](https://github.com/tetra-te/SimpleKerningEffect/releases/latest)からymmpファイルをダウンロードしてください。  

ダウンロードしたファイルを開いて、表示される画面に従ってインストールしてください。  
または、ダウンロードしたファイルをYMM4にドラッグアンドドロップして、表示される画面に従ってインストールしてください。  
## 使用方法
3つの映像エフェクト **簡易カーニング**, **文字間隔調整（横書）**, **文字間隔調整（縦書）** が追加されます。  
### 3つ全てのエフェクトで文字ごとに分割が必要です。テキストアイテムの文字ごとに分割を必ず有効にしてください。
### 簡易カーニングエフェクト
指定した文字の描画位置や拡大率を変更できます。  
**文字位置**に対象の文字を先頭から何文字目かで指定します。  
`,`(カンマ)を用いた複数指定、`-`(ハイフン)を用いた範囲指定が可能です。  
例えば1,2,5,6,7文字目を対象にする場合は次のような指定が可能です。  
* `1,2,5,6,7`
* `1,2,5-7`
* `1-2,5-7`  

半角スペースは無視されます。間違った指定をするとエフェクトが適用されません。  
### 文字間隔調整（横書,縦書）エフェクト
文字の一部分を対象に文字間隔を調整できるエフェクトです。テキストの設定によって横書と縦書を使い分けてください。  
**開始**から**終了**までの文字が対象になります。それぞれ、文字の先頭から何文字目かで指定します。  
**文字間隔**で、開始から終了までの範囲の文字間隔を調整します。
#### 全体を調整
これを有効にすると範囲内外の文字が重ならないように範囲外の文字の描画位置を調整します。
デフォルトで有効です。
## アンインストール方法
YMM4を起動して、`ヘルプ(H)`>`その他`>`プラグインフォルダを開く`をクリックしてください。  
`SimpleKerningEffect`または`SimpleKerningEffectCategory`という名前のフォルダを削除することでアンインストールできます。  
## ライセンス
[CC0 1.0 Universal](./LICENSE)