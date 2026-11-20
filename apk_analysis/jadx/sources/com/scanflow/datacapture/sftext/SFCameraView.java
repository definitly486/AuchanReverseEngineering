package com.scanflow.datacapture.sftext;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Color;
import android.graphics.Typeface;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.SurfaceView;
import android.view.View;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.camera.view.PreviewView;
import com.scanflow.datacapture.R;

/* JADX INFO: loaded from: classes3.dex */
public class SFCameraView extends FrameLayout {
    private TextView copyright;
    private ImageView img_card_flip;
    private Boolean isBorderCornersRounded;
    private Integer mBottomLeftColor;
    private Integer mBottomRightColor;
    private Integer mTopLeftColor;
    private Integer mTopRightColor;
    private OverlayView overlayView;
    private PreviewView previewView;
    private int ratioHeight;
    private int ratioWidth;
    private SurfaceView surfaceView;
    private Integer textCaptureHeightPercentage;
    private Integer textCaptureWidthPercentage;
    private TextView textView;

    public SFCameraView(Context context) {
        super(context, null);
        this.isBorderCornersRounded = Boolean.FALSE;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
        this.ratioWidth = 0;
        this.ratioHeight = 0;
    }

    public void doFlipAnimation(Context context) {
        AnimatorSet animatorSet = (AnimatorSet) AnimatorInflater.loadAnimator(context, R.animator.flip);
        animatorSet.setTarget(this.img_card_flip);
        animatorSet.addListener(new Animator.AnimatorListener() { // from class: com.scanflow.datacapture.sftext.SFCameraView.1
            @Override // android.animation.Animator.AnimatorListener
            public void onAnimationCancel(Animator animator) {
            }

            @Override // android.animation.Animator.AnimatorListener
            public void onAnimationEnd(Animator animator) {
                SFCameraView.this.img_card_flip.setVisibility(8);
            }

            @Override // android.animation.Animator.AnimatorListener
            public void onAnimationRepeat(Animator animator) {
            }

            @Override // android.animation.Animator.AnimatorListener
            public void onAnimationStart(Animator animator) {
                SFCameraView.this.img_card_flip.setVisibility(0);
            }
        });
        animatorSet.start();
    }

    public OverlayView getArOverlayView() {
        return this.overlayView;
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

    @Override // android.widget.FrameLayout, android.view.View
    public void onMeasure(int i, int i2) {
        int i3;
        super.onMeasure(i, i2);
        int size = View.MeasureSpec.getSize(i);
        int size2 = View.MeasureSpec.getSize(i2);
        int i4 = this.ratioWidth;
        if (i4 == 0 || (i3 = this.ratioHeight) == 0) {
            setMeasuredDimension(size, size2);
            return;
        }
        int i5 = (size2 * i4) / i3;
        if (size < i5) {
            setMeasuredDimension(size, (i3 * size) / i4);
        } else {
            setMeasuredDimension(i5, size2);
        }
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
        this.isBorderCornersRounded = Boolean.FALSE;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
        this.ratioWidth = 0;
        this.ratioHeight = 0;
        this.previewView = new PreviewView(context, attributeSet);
        this.surfaceView = new SurfaceView(context, attributeSet);
        this.overlayView = new OverlayView(context, attributeSet);
        TypedArray typedArrayObtainStyledAttributes = context.obtainStyledAttributes(attributeSet, R.styleable.SFCameraView);
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
        this.textView.setTextSize(18.0f);
        this.textView.setPadding(20, 0, 20, 0);
        this.textView.setTextColor(Color.parseColor("#C0C0C0"));
        this.textView.setText("The Scanflow SDK licence validation failed. Your licence key has expired!");
        TextView textView2 = new TextView(context, attributeSet);
        this.copyright = textView2;
        textView2.setGravity(85);
        this.copyright.setTextSize(10.0f);
        this.copyright.setTextColor(Color.parseColor("#FFFFFF"));
        this.copyright.setPadding(0, 0, 20, 20);
        this.copyright.setTypeface(Typeface.create(Typeface.DEFAULT, 0));
        this.copyright.setText("SCANFLOW");
        this.img_card_flip = new ImageView(context);
        int iApplyDimension = (int) TypedValue.applyDimension(2, 150.0f, getResources().getDisplayMetrics());
        int iApplyDimension2 = (int) TypedValue.applyDimension(2, 150.0f, getResources().getDisplayMetrics());
        this.img_card_flip.setImageResource(R.drawable.ic_flip_card);
        this.img_card_flip.setVisibility(8);
        FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(iApplyDimension2, iApplyDimension, 17);
        FrameLayout.LayoutParams layoutParams2 = new FrameLayout.LayoutParams(-2, -2, 17);
        FrameLayout.LayoutParams layoutParams3 = new FrameLayout.LayoutParams(-1, -1, 17);
        addView(this.previewView, layoutParams3);
        addView(this.surfaceView, layoutParams3);
        addView(this.overlayView, layoutParams2);
        addView(this.img_card_flip, layoutParams);
        addView(this.textView, layoutParams3);
        addView(this.copyright, layoutParams3);
        this.textView.setVisibility(8);
        this.previewView.setVisibility(0);
    }

    public SFCameraView(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, android.R.attr.alertDialogStyle);
        this.isBorderCornersRounded = Boolean.FALSE;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.textCaptureHeightPercentage = 0;
        this.textCaptureWidthPercentage = 0;
        this.ratioWidth = 0;
        this.ratioHeight = 0;
    }
}
