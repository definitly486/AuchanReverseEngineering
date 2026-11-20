package com.scanflow.ui;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.CornerPathEffect;
import android.graphics.Paint;
import android.graphics.Path;
import android.graphics.Point;
import android.graphics.Rect;
import android.graphics.Typeface;
import android.util.AttributeSet;
import android.view.View;
import androidx.core.content.ContextCompat;
import com.scanflow.datacapture.R;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class ViewFinderView extends View {
    private static final long ANIMATION_DELAY = 80;
    private static final float DEFAULT_SQUARE_DIMENSION_RATIO = 0.625f;
    private static final float LANDSCAPE_HEIGHT_RATIO = 0.625f;
    private static final float LANDSCAPE_WIDTH_HEIGHT_RATIO = 1.4f;
    private static final int MIN_DIMENSION_DIFF = 50;
    private static final int POINT_SIZE = 10;
    private static final float PORTRAIT_WIDTH_HEIGHT_RATIO = 0.75f;
    private static final float PORTRAIT_WIDTH_RATIO = 0.75f;
    private static final String TAG = "ViewFinderView";
    private final long ANIMATION_DELAY$1;
    private final float DEFAULT_SQUARE_DIMENSION_RATIO$1;
    private final float LANDSCAPE_HEIGHT_RATIO$1;
    private final float LANDSCAPE_WIDTH_HEIGHT_RATIO$1;
    private final int MIN_DIMENSION_DIFF$1;
    private final int POINT_SIZE$1;
    private final float PORTRAIT_WIDTH_HEIGHT_RATIO$1;
    private final float PORTRAIT_WIDTH_RATIO$1;
    private final int[] SCANNER_ALPHA$1;
    private final String TAG$1;
    private int borderCornersRadius;
    private boolean isBorderCornersRounded;
    private int mBorderLineLength;
    private Paint mBorderPaint;
    private float mBordersAlpha;
    private int mBottomLeftColor;
    private int mBottomRightColor;
    private final int mDefaultBorderColor;
    private final int mDefaultBorderLineLength;
    private final int mDefaultBorderStrokeWidth;
    private final int mDefaultLaserColor;
    private final int mDefaultMaskColor;
    private Paint mFinderMaskPaint;
    private Rect mFramingRect;
    private boolean mIsLaserEnabled;
    private Paint mLaserPaint;
    private boolean mSquareViewFinder;
    private int mTopLeftColor;
    private int mTopRightColor;
    private int mViewFinderOffset;
    private int scannerAlpha;
    public static final Companion Companion = new Companion(null);
    private static final int[] SCANNER_ALPHA = {0, 64, 128, 192, 255, 192, 128, 64};

    public static final class Companion {
        private Companion() {
        }

        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }
    }

    public ViewFinderView(Context context) {
        super(context);
        this.TAG$1 = TAG;
        this.PORTRAIT_WIDTH_RATIO$1 = 0.8125f;
        this.PORTRAIT_WIDTH_HEIGHT_RATIO$1 = 0.9f;
        this.LANDSCAPE_HEIGHT_RATIO$1 = 0.625f;
        this.LANDSCAPE_WIDTH_HEIGHT_RATIO$1 = LANDSCAPE_WIDTH_HEIGHT_RATIO;
        this.MIN_DIMENSION_DIFF$1 = 50;
        this.DEFAULT_SQUARE_DIMENSION_RATIO$1 = 0.625f;
        this.SCANNER_ALPHA$1 = new int[]{0, 64, 128, 192, 255, 192, 128, 64};
        this.POINT_SIZE$1 = 10;
        this.ANIMATION_DELAY$1 = ANIMATION_DELAY;
        this.mDefaultLaserColor = ContextCompat.getColor(getContext(), R.color.viewfinder_laser);
        this.mDefaultMaskColor = ContextCompat.getColor(getContext(), R.color.viewfinder_mask);
        this.mDefaultBorderColor = ContextCompat.getColor(getContext(), R.color.viewfinder_border);
        this.mDefaultBorderStrokeWidth = getResources().getInteger(R.integer.viewfinder_border_width);
        this.mDefaultBorderLineLength = getResources().getInteger(R.integer.viewfinder_border_length);
        this.mTopLeftColor = Color.parseColor("#2256DE");
        this.mTopRightColor = Color.parseColor("#FF543E");
        this.mBottomLeftColor = Color.parseColor("#FFAF4D");
        this.mBottomRightColor = Color.parseColor("#3098F1");
        init();
    }

    private final boolean attributeSetLoaded(Context context, AttributeSet attributeSet) {
        if (context == null) {
            return true;
        }
        TypedArray typedArrayObtainStyledAttributes = context.obtainStyledAttributes(attributeSet, R.styleable.ViewFinderView);
        Intrinsics.checkNotNullExpressionValue(typedArrayObtainStyledAttributes, "obtainStyledAttributes(...)");
        this.mTopLeftColor = typedArrayObtainStyledAttributes.getColor(R.styleable.ViewFinderView_topLeftCornerColor, ContextCompat.getColor(context, R.color.viewfinder_topleftcornor));
        this.mTopRightColor = typedArrayObtainStyledAttributes.getColor(R.styleable.ViewFinderView_topRightCornerColor, ContextCompat.getColor(context, R.color.viewfinder_toprightcornor));
        this.mBottomLeftColor = typedArrayObtainStyledAttributes.getColor(R.styleable.ViewFinderView_bottomLeftCornerColor, ContextCompat.getColor(context, R.color.viewfinder_bottomleftcornor));
        this.mBottomRightColor = typedArrayObtainStyledAttributes.getColor(R.styleable.ViewFinderView_bottomRightCornerColor, ContextCompat.getColor(context, R.color.viewfinder_bottomrightcornor));
        boolean z = typedArrayObtainStyledAttributes.getBoolean(R.styleable.ViewFinderView_roundedCorner, false);
        this.isBorderCornersRounded = z;
        if (!z) {
            return true;
        }
        this.borderCornersRadius = (int) typedArrayObtainStyledAttributes.getDimension(R.styleable.ViewFinderView_cornerRadius, 20.0f);
        return true;
    }

    private final void init() {
        Paint paint = new Paint();
        this.mLaserPaint = paint;
        Intrinsics.checkNotNull(paint);
        paint.setColor(this.mDefaultLaserColor);
        Paint paint2 = this.mLaserPaint;
        Intrinsics.checkNotNull(paint2);
        paint2.setStyle(Paint.Style.FILL);
        Paint paint3 = new Paint();
        this.mFinderMaskPaint = paint3;
        Intrinsics.checkNotNull(paint3);
        paint3.setColor(this.mDefaultMaskColor);
        Paint paint4 = new Paint();
        this.mBorderPaint = paint4;
        Intrinsics.checkNotNull(paint4);
        paint4.setColor(this.mDefaultBorderColor);
        Paint paint5 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint5);
        paint5.setStyle(Paint.Style.STROKE);
        Paint paint6 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint6);
        paint6.setStrokeWidth(this.mDefaultBorderStrokeWidth);
        Paint paint7 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint7);
        paint7.setAntiAlias(true);
        if (this.isBorderCornersRounded) {
            Paint paint8 = this.mBorderPaint;
            Intrinsics.checkNotNull(paint8);
            paint8.setStrokeJoin(Paint.Join.ROUND);
            Paint paint9 = this.mBorderPaint;
            Intrinsics.checkNotNull(paint9);
            paint9.setPathEffect(new CornerPathEffect(this.borderCornersRadius));
        } else {
            Paint paint10 = this.mBorderPaint;
            Intrinsics.checkNotNull(paint10);
            paint10.setStrokeJoin(Paint.Join.BEVEL);
        }
        this.mBorderLineLength = this.mDefaultBorderLineLength;
    }

    public final void drawLaser(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        Rect rect = this.mFramingRect;
        Paint paint = this.mLaserPaint;
        Intrinsics.checkNotNull(paint);
        paint.setAlpha(this.SCANNER_ALPHA$1[this.scannerAlpha]);
        this.scannerAlpha = (this.scannerAlpha + 1) % this.SCANNER_ALPHA$1.length;
        Intrinsics.checkNotNull(rect);
        int iHeight = (rect.height() / 2) + rect.top;
        Paint paint2 = this.mLaserPaint;
        Intrinsics.checkNotNull(paint2);
        canvas.drawRect(rect.left + 2, iHeight - 1, rect.right - 1, iHeight + 2, paint2);
        long j = this.ANIMATION_DELAY$1;
        int i = rect.left;
        int i2 = this.POINT_SIZE$1;
        postInvalidateDelayed(j, i - i2, rect.top - i2, rect.right + i2, rect.bottom + i2);
    }

    public final void drawViewFinderBorder(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        Rect rect = this.mFramingRect;
        Intrinsics.checkNotNull(rect);
        new Paint(1).setColor(ContextCompat.getColor(getContext(), R.color.design_default_color_background));
        Path path = new Path();
        Paint paint = this.mBorderPaint;
        Intrinsics.checkNotNull(paint);
        paint.setColor(this.mTopLeftColor);
        Intrinsics.checkNotNull(rect);
        path.moveTo(rect.left, rect.top + this.mBorderLineLength);
        path.lineTo(rect.left, rect.top);
        path.lineTo(rect.left + this.mBorderLineLength, rect.top);
        Paint paint2 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint2);
        canvas.drawPath(path, paint2);
        Path path2 = new Path();
        Paint paint3 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint3);
        paint3.setColor(this.mTopRightColor);
        path2.moveTo(rect.right, rect.top + this.mBorderLineLength);
        path2.lineTo(rect.right, rect.top);
        path2.lineTo(rect.right - this.mBorderLineLength, rect.top);
        Paint paint4 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint4);
        canvas.drawPath(path2, paint4);
        Path path3 = new Path();
        Paint paint5 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint5);
        paint5.setColor(this.mBottomRightColor);
        path3.moveTo(rect.right, rect.bottom - this.mBorderLineLength);
        path3.lineTo(rect.right, rect.bottom);
        path3.lineTo(rect.right - this.mBorderLineLength, rect.bottom);
        Paint paint6 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint6);
        canvas.drawPath(path3, paint6);
        Path path4 = new Path();
        Paint paint7 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint7);
        paint7.setColor(this.mBottomLeftColor);
        path4.moveTo(rect.left, rect.bottom - this.mBorderLineLength);
        path4.lineTo(rect.left, rect.bottom);
        path4.lineTo(rect.left + this.mBorderLineLength, rect.bottom);
        Paint paint8 = this.mBorderPaint;
        Intrinsics.checkNotNull(paint8);
        canvas.drawPath(path4, paint8);
        Paint paint9 = new Paint();
        paint9.setColor(-1);
        paint9.setTextSize(20.0f);
        paint9.setTypeface(Typeface.create(Typeface.DEFAULT, 0));
        canvas.drawText("SCANFLOW", (rect.right - this.mBorderLineLength) - 35, rect.bottom + 50, paint9);
    }

    public final void drawViewFinderMask(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        int width = canvas.getWidth();
        int height = canvas.getHeight();
        Rect rect = this.mFramingRect;
        float f = width;
        Intrinsics.checkNotNull(rect);
        float f2 = rect.top;
        Paint paint = this.mFinderMaskPaint;
        Intrinsics.checkNotNull(paint);
        canvas.drawRect(0.0f, 0.0f, f, f2, paint);
        float f3 = rect.top;
        float f4 = rect.left;
        float f5 = rect.bottom + 1;
        Paint paint2 = this.mFinderMaskPaint;
        Intrinsics.checkNotNull(paint2);
        canvas.drawRect(0.0f, f3, f4, f5, paint2);
        float f6 = rect.right + 1;
        float f7 = rect.top;
        float f8 = rect.bottom + 1;
        Paint paint3 = this.mFinderMaskPaint;
        Intrinsics.checkNotNull(paint3);
        canvas.drawRect(f6, f7, f, f8, paint3);
        Paint paint4 = this.mFinderMaskPaint;
        Intrinsics.checkNotNull(paint4);
        canvas.drawRect(0.0f, rect.bottom + 1, f, height, paint4);
    }

    public final int getMBorderLineLength() {
        return this.mBorderLineLength;
    }

    public final Paint getMBorderPaint() {
        return this.mBorderPaint;
    }

    public final Paint getMFinderMaskPaint() {
        return this.mFinderMaskPaint;
    }

    public final Paint getMLaserPaint() {
        return this.mLaserPaint;
    }

    public final boolean getMSquareViewFinder() {
        return this.mSquareViewFinder;
    }

    @Override // android.view.View
    public void onDraw(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        if (this.mFramingRect == null) {
            return;
        }
        drawViewFinderBorder(canvas);
        if (this.mIsLaserEnabled) {
            drawLaser(canvas);
        }
    }

    @Override // android.view.View
    public void onSizeChanged(int i, int i2, int i3, int i4) {
        updateFramingRect();
    }

    @Override // android.view.View
    public void onVisibilityChanged(View changedView, int i) {
        Intrinsics.checkNotNullParameter(changedView, "changedView");
        super.onVisibilityChanged(changedView, i);
    }

    public void setBorderAlpha(float f) {
        int i = (int) (255 * f);
        this.mBordersAlpha = f;
        Paint paint = this.mBorderPaint;
        Intrinsics.checkNotNull(paint);
        paint.setAlpha(i);
    }

    public void setBorderColor(int i) {
        Paint paint = this.mBorderPaint;
        Intrinsics.checkNotNull(paint);
        paint.setColor(i);
    }

    public void setBorderCornerRadius(int i) {
        Paint paint = this.mBorderPaint;
        Intrinsics.checkNotNull(paint);
        paint.setPathEffect(new CornerPathEffect(i));
    }

    public void setBorderCornerRounded(boolean z) {
        Paint paint;
        Paint.Join join;
        if (z) {
            paint = this.mBorderPaint;
            Intrinsics.checkNotNull(paint);
            join = Paint.Join.ROUND;
        } else {
            paint = this.mBorderPaint;
            Intrinsics.checkNotNull(paint);
            join = Paint.Join.BEVEL;
        }
        paint.setStrokeJoin(join);
    }

    public void setBorderLineLength(int i) {
        this.mBorderLineLength = i;
    }

    public void setBorderStrokeWidth(int i) {
        Paint paint = this.mBorderPaint;
        Intrinsics.checkNotNull(paint);
        paint.setStrokeWidth(i);
    }

    public void setBottomLeftCornerColor(int i) {
        this.mBottomLeftColor = i;
    }

    public void setBottomRightCornerColor(int i) {
        this.mBottomRightColor = i;
    }

    public void setLaserColor(int i) {
        Paint paint = this.mLaserPaint;
        Intrinsics.checkNotNull(paint);
        paint.setColor(i);
    }

    public void setLaserEnabled(boolean z) {
        this.mIsLaserEnabled = z;
    }

    public final void setMBorderLineLength(int i) {
        this.mBorderLineLength = i;
    }

    public final void setMBorderPaint(Paint paint) {
        this.mBorderPaint = paint;
    }

    public final void setMFinderMaskPaint(Paint paint) {
        this.mFinderMaskPaint = paint;
    }

    public final void setMLaserPaint(Paint paint) {
        this.mLaserPaint = paint;
    }

    public final void setMSquareViewFinder(boolean z) {
        this.mSquareViewFinder = z;
    }

    public void setMaskColor(int i) {
        Paint paint = this.mFinderMaskPaint;
        Intrinsics.checkNotNull(paint);
        paint.setColor(i);
    }

    public void setSquareViewFinder(boolean z) {
        this.mSquareViewFinder = z;
    }

    public void setTopLeftCornerColor(int i) {
        this.mTopLeftColor = i;
    }

    public void setTopRightCornerColor(int i) {
        this.mTopRightColor = i;
    }

    public void setViewFinderOffset(int i) {
        this.mViewFinderOffset = i;
    }

    public void setupViewFinder() {
        updateFramingRect();
        invalidate();
    }

    public final synchronized void updateFramingRect() {
        int width;
        int height;
        try {
            Point point = new Point(getWidth(), getHeight());
            int i = getContext().getResources().getConfiguration().orientation;
            if (this.mSquareViewFinder) {
                width = (int) ((i != 1 ? getHeight() : getWidth()) * this.DEFAULT_SQUARE_DIMENSION_RATIO$1);
                height = width;
            } else if (i != 1) {
                int height2 = (int) (getHeight() * this.LANDSCAPE_HEIGHT_RATIO$1);
                height = height2;
                width = (int) (this.LANDSCAPE_WIDTH_HEIGHT_RATIO$1 * height2);
            } else {
                width = (int) (getWidth() * this.PORTRAIT_WIDTH_RATIO$1);
                height = (int) (this.PORTRAIT_WIDTH_HEIGHT_RATIO$1 * width);
            }
            if (width > getWidth()) {
                width = getWidth() - this.MIN_DIMENSION_DIFF$1;
            }
            if (height > getHeight()) {
                height = getHeight() - this.MIN_DIMENSION_DIFF$1;
            }
            int i2 = (point.x - width) / 2;
            int i3 = (point.y - height) / 2;
            int i4 = this.mViewFinderOffset;
            this.mFramingRect = new Rect(i2 + i4, i3 + i4, (i2 + width) - i4, (i3 + height) - i4);
        } catch (Throwable th) {
            throw th;
        }
    }

    public ViewFinderView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        this.TAG$1 = TAG;
        this.PORTRAIT_WIDTH_RATIO$1 = 0.8125f;
        this.PORTRAIT_WIDTH_HEIGHT_RATIO$1 = 0.9f;
        this.LANDSCAPE_HEIGHT_RATIO$1 = 0.625f;
        this.LANDSCAPE_WIDTH_HEIGHT_RATIO$1 = LANDSCAPE_WIDTH_HEIGHT_RATIO;
        this.MIN_DIMENSION_DIFF$1 = 50;
        this.DEFAULT_SQUARE_DIMENSION_RATIO$1 = 0.625f;
        this.SCANNER_ALPHA$1 = new int[]{0, 64, 128, 192, 255, 192, 128, 64};
        this.POINT_SIZE$1 = 10;
        this.ANIMATION_DELAY$1 = ANIMATION_DELAY;
        this.mDefaultLaserColor = ContextCompat.getColor(getContext(), R.color.viewfinder_laser);
        this.mDefaultMaskColor = ContextCompat.getColor(getContext(), R.color.viewfinder_mask);
        this.mDefaultBorderColor = ContextCompat.getColor(getContext(), R.color.viewfinder_border);
        this.mDefaultBorderStrokeWidth = getResources().getInteger(R.integer.viewfinder_border_width);
        this.mDefaultBorderLineLength = getResources().getInteger(R.integer.viewfinder_border_length);
        this.mTopLeftColor = Color.parseColor("#2256DE");
        this.mTopRightColor = Color.parseColor("#FF543E");
        this.mBottomLeftColor = Color.parseColor("#FFAF4D");
        this.mBottomRightColor = Color.parseColor("#3098F1");
        if (attributeSetLoaded(context, attributeSet)) {
            init();
        }
    }
}
