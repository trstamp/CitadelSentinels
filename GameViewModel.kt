package com.tylerstamp.towerdefenseversus

import android.content.res.Resources
import android.graphics.BitmapFactory
import android.graphics.Canvas
import androidx.lifecycle.ViewModel

class GameViewModel : ViewModel() {
    private val screenWidth = Resources.getSystem().displayMetrics.widthPixels.toFloat()
    private val screenHeight = Resources.getSystem().displayMetrics.heightPixels.toFloat()

    private val sprites = arrayOf(
        mutableListOf<Sprite>()
    )
    private val actionItem = arrayOf(
        mutableListOf<ActionItem>()
    )
    private val updatables = arrayOf(
        mutableListOf<Updatable>()
    )
    private var loaded = false

    private lateinit var tiles: TiledBitmap
    val numCols = 10
    val numRows = 10
    val contents = Array(numCols * numRows){0}
    private val baseContents = Array(numCols * numRows){0}
    private val stoneContents = Array(numCols * numRows){0}


    fun load(resources: Resources?) {
        if (!loaded)
        {
            loaded = true
            //
            for(y in 0 until numRows) {
                for(x in 0 until numCols) {
                    val idx = x + numCols * y
                    baseContents[idx] = 10
                    stoneContents[idx] = 0
                }
            }
            for(y in 0 until numRows) {
                baseContents[numCols * y] -= 1
                baseContents[numCols * y + numCols - 1] += 1
            }
            for(x in 0 until numCols) {
                baseContents[x] -= 9
                baseContents[x + (numRows - 1) * numCols] += 9
            }
            for(y in 0 until numRows) {
                for(x in 0 until numCols) {
                    val idx = x + numCols * y
                    contents[idx] = baseContents[idx] + stoneContents[idx]
                }
            }
            val tileImage = BitmapFactory.decodeResource(resources, R.drawable.go_tiles)
            tiles = TiledBitmap(tileImage, 9, 3)
            val boardSprite = BoardSprite(tiles, this, 100.0f, 100.0f)

        }
    }
    fun doClick(x: Int, y: Int): Boolean {
        //
        var any = false
        for(item in actionItem) {
            if(item.doClick(x, y)) {
                any = true
            }
        }
        return any
    }
    fun draw(canvas: Canvas) {
        //
        for(sprite in sprites)
            sprite.draw(canvas)
    }
    fun update() {
        //
        for(updateable in updatables)
            updateable.update()
    }

}