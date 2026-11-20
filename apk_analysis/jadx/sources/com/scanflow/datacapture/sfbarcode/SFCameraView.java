package com.scanflow.datacapture.sfbarcode;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Color;
import android.util.AttributeSet;
import android.view.SurfaceView;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.camera.view.PreviewView;
import com.scanflow.datacapture.R;
import com.scanflow.datacapture.sfcamera.OverlayView;
import com.scanflow.ui.ViewFinderView;
import com.scanflow.ui.ar.ArOverlayView;

/* JADX INFO: loaded from: classes3.dex */
public class SFCameraView extends FrameLayout {
    private ArOverlayView arOverlayView;
    private ImageView imgPointerScanLine;
    private Boolean isBorderCornersRounded;
    private Integer mBottomLeftColor;
    private Integer mBottomRightColor;
    private Integer mTopLeftColor;
    private Integer mTopRightColor;
    private OverlayView overlayView;
    private PreviewView previewView;
    private Boolean showPointerScanLine;
    private SurfaceView surfaceView;
    private Integer textCaptureHeightPercentage;
    private Integer textCaptureWidthPercentage;
    private TextView textView;
    private ViewFinderView viewFinderView;

    public SFCameraView(Context context) {
        super(context, null);
        Boolean bool = Boolean.FALSE;
        this.showPointerScanLine = bool;
        this.isBorderCornersRounded = bool;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
    }

    public ArOverlayView getArOverlayView() {
        return this.arOverlayView;
    }

    public PreviewView getPreviewView() {
        return this.previewView;
    }

    public SurfaceView getSurfaceView() {
        return this.surfaceView;
    }

    public Boolean isBorderCornersRounded() {
        return this.isBorderCornersRounded;
    }

    public Integer mBottomLeftColor() {
        return this.mBottomLeftColor;
    }

    public Integer mBottomRightColor() {
        return this.mBottomRightColor;
    }

    public Integer mTopLeftColor() {
        return this.mTopLeftColor;
    }

    public Integer mTopRightColor() {
        return this.mTopRightColor;
    }

    public void setExpiredVisibility(Boolean bool, String str) {
        TextView textView;
        int i;
        if (bool.booleanValue()) {
            this.textView.setText(str);
            textView = this.textView;
            i = 0;
        } else {
            textView = this.textView;
            i = 8;
        }
        textView.setVisibility(i);
    }

    public Integer textCaptureHeightPercentage() {
        return Integer.valueOf(100 - this.textCaptureHeightPercentage.intValue());
    }

    public Integer textCaptureWidthPercentage() {
        return Integer.valueOf(100 - this.textCaptureWidthPercentage.intValue());
    }

    public SFCameraView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet, 0);
        Boolean bool = Boolean.FALSE;
        this.showPointerScanLine = bool;
        this.isBorderCornersRounded = bool;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
        this.previewView = new PreviewView(context, attributeSet);
        this.surfaceView = new SurfaceView(context, attributeSet);
        this.arOverlayView = new ArOverlayView(context, attributeSet);
        this.overlayView = new OverlayView(context, attributeSet);
        TypedArray typedArrayObtainStyledAttributes = context.obtainStyledAttributes(attributeSet, R.styleable.SFCameraView);
        this.showPointerScanLine = Boolean.valueOf(typedArrayObtainStyledAttributes.getBoolean(R.styleable.SFCameraView_showPointerScanLine, false));
        this.isBorderCornersRounded = Boolean.valueOf(typedArrayObtainStyledAttributes.getBoolean(R.styleable.SFCameraView_roundedCorner, false));
        this.mTopLeftColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_topLeftCornerColor, Color.parseColor("#2256DE")));
        this.mTopRightColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_topRightCornerColor, Color.parseColor("#FF543E")));
        this.mBottomLeftColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_bottomLeftCornerColor, Color.parseColor("#FFAF4D")));
        this.mBottomRightColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_bottomRightCornerColor, Color.parseColor("#3098F1")));
        this.textCaptureHeightPercentage = Integer.valueOf(typedArrayObtainStyledAttributes.getInteger(R.styleable.SFCameraView_textCaptureHeightPercentage, 0));
        this.textCaptureWidthPercentage = Integer.valueOf(typedArrayObtainStyledAttributes.getInteger(R.styleable.SFCameraView_textCaptureWidthPercentage, 0));
        TextView textView = new TextView(context, attributeSet);
        this.textView = textView;
        textView.setGravity(17);
        this.textView.setTextSize(16.0f);
        this.textView.setPadding(20, 0, 20, 0);
        this.textView.setTextColor(Color.parseColor("#C0C0C0"));
        this.textView.setText("The Scanflow SDK licence validation failed. Your licence key has expired!");
        ImageView imageView = new ImageView(context, attributeSet);
        this.imgPointerScanLine = imageView;
        imageView.setImageResource(R.drawable.ic_pivot_view_center_line);
        FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(-2, -2, 17);
        FrameLayout.LayoutParams layoutParams2 = new FrameLayout.LayoutParams(-1, -1, 17);
        addView(this.previewView, layoutParams2);
        addView(this.surfaceView, layoutParams2);
        addView(this.imgPointerScanLine, layoutParams2);
        addView(this.overlayView, layoutParams);
        addView(this.arOverlayView, layoutParams2);
        addView(this.textView, layoutParams2);
        if (this.showPointerScanLine.booleanValue()) {
            this.imgPointerScanLine.setVisibility(0);
        } else {
            this.imgPointerScanLine.setVisibility(8);
        }
        this.textView.setVisibility(8);
        this.previewView.setVisibility(0);
    }

    public SFCameraView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, android.R.attr.alertDialogStyle);
        Boolean bool = Boolean.FALSE;
        this.showPointerScanLine = bool;
        this.isBorderCornersRounded = bool;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
    }
}
