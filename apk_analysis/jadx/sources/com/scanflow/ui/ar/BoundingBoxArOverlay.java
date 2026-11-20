package com.scanflow.ui.ar;

import android.content.Context;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Paint;
import android.graphics.RectF;
import com.scanflow.datacapture.R;
import java.util.ArrayList;
import java.util.Iterator;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import org.tensorflow.lite.schema.BuiltinOperator;

/* JADX INFO: loaded from: classes3.dex */
public final class BoundingBoxArOverlay extends a implements ArObjectTracker.ArObjectTrackingListener {
    private ArrayList<ArObject> arObject;
    private final Paint boundingBoxBorderPaint;
    private final Paint boundingBoxFillPaint;
    private final Context context;
    private final float cornerRadius;
    private RectF currentBoundingBox;
    private String currentTrackingId;
    private final boolean debugMode;
    private final Paint textPaint;

    public BoundingBoxArOverlay(Context context, boolean z) {
        Intrinsics.checkNotNullParameter(context, "context");
        this.context = context;
        this.debugMode = z;
        float dimension = context.getResources().getDimension(R.dimen.ar_bounding_box_corner_radius);
        this.cornerRadius = dimension;
        this.arObject = new ArrayList<>();
        Paint paint = new Paint();
        paint.setStrokeWidth(context.getResources().getDimension(R.dimen.ar_bounding_rect_stroke_width));
        paint.setStyle(Paint.Style.STROKE);
        paint.setAntiAlias(true);
        this.boundingBoxBorderPaint = paint;
        Paint paint2 = new Paint();
        paint2.setStyle(Paint.Style.FILL);
        paint2.setAntiAlias(true);
        this.boundingBoxFillPaint = paint2;
        Paint paint3 = new Paint();
        paint3.setColor(-1);
        paint3.setTextSize(dimension);
        paint3.setAntiAlias(true);
        this.textPaint = paint3;
        setBoundingBoxColor(-1);
    }

    @Override // com.scanflow.ui.ar.a
    public void onDraw(Canvas canvas) {
        Intrinsics.checkNotNullParameter(canvas, "canvas");
        RectF rectF = this.currentBoundingBox;
        if (rectF != null) {
            Intrinsics.checkNotNull(rectF);
            float f = this.cornerRadius;
            canvas.drawRoundRect(rectF, f, f, this.boundingBoxFillPaint);
            RectF rectF2 = this.currentBoundingBox;
            Intrinsics.checkNotNull(rectF2);
            float f2 = this.cornerRadius;
            canvas.drawRoundRect(rectF2, f2, f2, this.boundingBoxBorderPaint);
            if (this.debugMode) {
                String strValueOf = String.valueOf(this.currentTrackingId);
                RectF rectF3 = this.currentBoundingBox;
                Intrinsics.checkNotNull(rectF3);
                float f3 = rectF3.left + this.cornerRadius;
                RectF rectF4 = this.currentBoundingBox;
                Intrinsics.checkNotNull(rectF4);
                canvas.drawText(strValueOf, f3, rectF4.bottom - this.cornerRadius, this.textPaint);
                return;
            }
            return;
        }
        if (this.arObject.size() > 0) {
            Iterator<ArObject> it = this.arObject.iterator();
            Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
            while (it.hasNext()) {
                ArObject next = it.next();
                Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                ArObject arObject = next;
                setBoundingBoxColor(arObject.getBboxcolor());
                if (arObject.getShowtickimage()) {
                    Resources resources = this.context.getResources();
                    Intrinsics.checkNotNullExpressionValue(resources, "getResources(...)");
                    Bitmap bitmapDecodeResource = BitmapFactory.decodeResource(resources, R.drawable.ic_blue_tick_20);
                    canvas.drawBitmap(bitmapDecodeResource, arObject.getBoundingBox().centerX() - (bitmapDecodeResource.getWidth() / 2), arObject.getBoundingBox().centerY() - (bitmapDecodeResource.getHeight() / 2), new Paint());
                }
                RectF boundingBox = arObject.getBoundingBox();
                float f4 = this.cornerRadius;
                canvas.drawRoundRect(boundingBox, f4, f4, this.boundingBoxFillPaint);
                RectF boundingBox2 = arObject.getBoundingBox();
                float f5 = this.cornerRadius;
                canvas.drawRoundRect(boundingBox2, f5, f5, this.boundingBoxBorderPaint);
            }
        }
    }

    @Override // com.scanflow.ui.ar.ArObjectTracker.ArObjectTrackingListener
    public void onObjectTracked(ArObject arObject) {
        this.currentBoundingBox = arObject != null ? arObject.getBoundingBox() : null;
        this.currentTrackingId = arObject != null ? arObject.getTrackingId() : null;
        if (arObject != null) {
            setBoundingBoxColor(arObject.getBboxcolor());
        }
        ArOverlayView host = getHost();
        if (host != null) {
            host.invalidate();
        }
    }

    public final void setBoundingBoxColor(int i) {
        this.boundingBoxBorderPaint.setColor(i);
        this.boundingBoxBorderPaint.setAlpha(BuiltinOperator.UNSORTED_SEGMENT_PROD);
        this.boundingBoxFillPaint.setColor(i);
        this.boundingBoxFillPaint.setAlpha(51);
        ArOverlayView host = getHost();
        if (host != null) {
            host.invalidate();
        }
    }

    public /* synthetic */ BoundingBoxArOverlay(Context context, boolean z, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this(context, (i & 2) != 0 ? false : z);
    }

    @Override // com.scanflow.ui.ar.ArObjectTracker.ArObjectTrackingListener
    public void onObjectTracked(ArrayList<ArObject> arObject) {
        Intrinsics.checkNotNullParameter(arObject, "arObject");
        this.arObject = arObject;
        ArOverlayView host = getHost();
        if (host != null) {
            host.invalidate();
        }
    }
}
