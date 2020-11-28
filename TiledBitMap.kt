package com.tylerstamp.towerdefenseversus

import android.graphics.Bitmap

class TiledBitmap(
    private val image: Bitmap,
    private val numCols: Int,
    numRows: Int
) {
    private val bitmapWid: Int = image.width
    private val bitmapHgt: Int = image.height
    val iconWid = bitmapWid / numCols
    val iconHgt = bitmapHgt / numRows
    private val subImages = Array<Bitmap?>(numCols * numRows){null}

    fun getImage(col: Int, row: Int) : Bitmap {
        val idx = col + numCols * row
        return subImages[idx] ?: makeImage(col, row)
    }

    fun getImageByIndex(idx: Int) : Bitmap {
        val col = idx % numCols
        val row = idx / numCols
        return subImages[idx] ?: makeImage(col, row)
    }

    private fun makeImage(col: Int, row: Int) : Bitmap {
        val idx = col + numCols * row
        val subImage = Bitmap.createBitmap(
            image,
            col * iconWid,
            row * iconHgt,
            iconWid,
            iconHgt)
        subImages[idx] = subImage
        return subImage
    }
}