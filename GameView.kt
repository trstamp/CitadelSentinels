package com.tylerstamp.towerdefenseversus

import android.content.Context
import android.graphics.Canvas
import android.graphics.Color
import android.view.MotionEvent
import android.view.SurfaceHolder
import android.view.SurfaceView

class GameView(context: Context) : SurfaceView(context), SurfaceHolder.Callback {
    private val gameThread: GameThread
    private lateinit var gameViewModel: GameViewModel

    init{
        holder.addCallback(this)
        gameThread = GameThread(holder, this)
        isFocusable = true
    }

    fun attachViewModel(model: GameViewModel): GameView {
        gameViewModel = model
        gameThread.attachViewModel(model)
        return this;
    }

    override fun surfaceChanged(holder: SurfaceHolder, format: Int, width: Int, height: Int) {

    }
    override fun surfaceCreated(holder: SurfaceHolder) {
        gameThread.setRunning(true)
        gameThread.start()
    }
    override fun surfaceDestroyed(holder: SurfaceHolder) {
        var retry = true
        while (retry) {
            try {
                gameThread.setRunning(false)
                gameThread.join()
            } catch (e: InterruptedException) {
                e.printStackTrace()
            }
            retry = false
        }
    }

    override fun onTouchEvent(event: MotionEvent):Boolean {
        if (event.action == MotionEvent.ACTION_DOWN)
        {
            val x = event.x.toInt()
            val y = event.y.toInt()
            return gameThread.doClick(x, y)
        }
        return false
    }
    override fun draw(canvas: Canvas) {
        super.draw(canvas)
        canvas.drawColor(Color.BLACK)
        gameViewModel.draw(canvas)
    }

}