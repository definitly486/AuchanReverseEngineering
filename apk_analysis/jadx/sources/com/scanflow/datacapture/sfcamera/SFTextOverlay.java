package com.scanflow.datacapture.sfcamera;

import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.CornerPathEffect;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.PorterDuff;
import android.graphics.PorterDuffXfermode;
import android.graphics.RectF;
import android.graphics.Typeface;
import android.view.SurfaceHolder;
import android.view.SurfaceView;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class SFTextOverlay {
    public static final SFTextOverlay INSTANCE = new SFTextOverlay();
    private static boolean isBorderCornersRounded = true;
    private static int mTopLeftColor = Color.parseColor("#2256DE");
    private static int mTopRightColor = Color.parseColor("#FF543E");
    private static int mBottomLeftColor = Color.parseColor("#FFAF4D");
    private static int mBottomRightColor = Color.parseColor("#3098F1");

    private SFTextOverlay() {
    }

    public final RectF drawOverlay(SurfaceHolder holder, int i, int i2) {
        Intrinsics.checkNotNullParameter(holder, "holder");
        Canvas canvasLockCanvas = holder.lockCanvas();
        Paint paint = new Paint();
        paint.setAlpha(60);
        canvasLockCanvas.drawPaint(paint);
        Paint paint2 = new Paint();
        paint2.setXfermode(new PorterDuffXfermode(PorterDuff.Mode.CLEAR));
        paint2.setStyle(Paint.Style.FILL);
        paint2.setColor(-1);
        Paint paint3 = new Paint();
        Paint.Style style = Paint.Style.STROKE;
        paint3.setStyle(style);
        paint3.setColor(-1);
        paint3.setStrokeWidth(4.0f);
        int iWidth = holder.getSurfaceFrame().width();
        int iHeight = holder.getSurfaceFrame().height();
        float f = ((iHeight * i) / 2) / 100.0f;
        float f2 = ((iWidth * i2) / 2) / 100.0f;
        float f3 = 1;
        float f4 = (f3 - ((i2 / 2) / 100.0f)) * iWidth;
        float f5 = (f3 - ((i / 2) / 100.0f)) * iHeight;
        RectF rectF = new RectF(f2, f, f4, f5);
        canvasLockCanvas.drawRoundRect(rectF, 10.0f, 10.0f, paint2);
        Paint paint4 = new Paint();
        paint4.setColor(mTopLeftColor);
        paint4.setStyle(style);
        paint4.setStrokeWidth(5.0f);
        paint4.setAntiAlias(true);
        if (isBorderCornersRounded) {
            paint4.setStrokeJoin(Paint.Join.ROUND);
            paint4.setPathEffect(new CornerPathEffect(20.0f));
        } else {
            paint4.setStrokeJoin(Paint.Join.BEVEL);
        }
        Path path = new Path();
        float f6 = 60;
        float f7 = f + f6;
        path.moveTo(f2, f7);
        path.lineTo(f2, f);
        float f8 = f2 + f6;
        path.lineTo(f8, f);
        canvasLockCanvas.drawPath(path, paint4);
        Path path2 = new Path();
        paint4.setColor(mTopRightColor);
        path2.moveTo(f4, f7);
        path2.lineTo(f4, f);
        float f9 = f4 - f6;
        path2.lineTo(f9, f);
        canvasLockCanvas.drawPath(path2, paint4);
        Path path3 = new Path();
        paint4.setColor(mBottomRightColor);
        float f10 = f5 - f6;
        path3.moveTo(f4, f10);
        path3.lineTo(f4, f5);
        path3.lineTo(f9, f5);
        canvasLockCanvas.drawPath(path3, paint4);
        Path path4 = new Path();
        paint4.setColor(mBottomLeftColor);
        path4.moveTo(f2, f10);
        path4.lineTo(f2, f5);
        path4.lineTo(f8, f5);
        canvasLockCanvas.drawPath(path4, paint4);
        Paint paint5 = new Paint();
        paint5.setColor(-1);
        paint5.setTextSize(34.0f);
        paint5.setTypeface(Typeface.create(Typeface.DEFAULT, 1));
        holder.unlockCanvasAndPost(canvasLockCanvas);
        return rectF;
    }

    public final int getMBottomLeftColor() {
        return mBottomLeftColor;
    }

    public final int getMBottomRightColor() {
        return mBottomRightColor;
    }

    public final int getMTopLeftColor() {
        return mTopLeftColor;
    }

    public final int getMTopRightColor() {
        return mTopRightColor;
    }

    public final boolean isBorderCornersRounded() {
        return isBorderCornersRounded;
    }

    public final void setBorderCornersRounded(boolean z) {
        isBorderCornersRounded = z;
    }

    public final void setMBottomLeftColor(int i) {
        mBottomLeftColor = i;
    }

    public final void setMBottomRightColor(int i) {
        mBottomRightColor = i;
    }

    public final void setMTopLeftColor(int i) {
        mTopLeftColor = i;
    }

    public final void setMTopRightColor(int i) {
        mTopRightColor = i;
    }

    public final void setTextCaptureOverlay(final SurfaceView surfaceView, final int i, final int i2, int i3, int i4, int i5, int i6, boolean z) {
        Intrinsics.checkNotNullParameter(surfaceView, "surfaceView");
        isBorderCornersRounded = z;
        mTopLeftColor = i3;
        mTopRightColor = i4;
        mBottomLeftColor = i5;
        mBottomRightColor = i6;
        surfaceView.setZOrderMediaOverlay(true);
        surfaceView.getHolder().setFormat(-2);
        surfaceView.getHolder().addCallback(new SurfaceHolder.Callback() { // from class: com.scanflow.datacapture.sfcamera.SFTextOverlay$setTextCaptureOverlay$1$1
            @Override // android.view.SurfaceHolder.Callback
            public void surfaceChanged(SurfaceHolder holder, int i7, int i8, int i9) {
                Intrinsics.checkNotNullParameter(holder, "holder");
                surfaceView.invalidate();
            }

            @Override // android.view.SurfaceHolder.Callback
            public void surfaceCreated(SurfaceHolder holder) {
                Intrinsics.checkNotNullParameter(holder, "holder");
                SurfaceView surfaceView2 = surfaceView;
                int i7 = i;
                int i8 = i2;
                surfaceView2.setWillNotDraw(false);
                SFTextOverlay.INSTANCE.drawOverlay(holder, i7, i8);
            }

            @Override // android.view.SurfaceHolder.Callback
            public void surfaceDestroyed(SurfaceHolder holder) {
                Intrinsics.checkNotNullParameter(holder, "holder");
            }
        });
    }
}
