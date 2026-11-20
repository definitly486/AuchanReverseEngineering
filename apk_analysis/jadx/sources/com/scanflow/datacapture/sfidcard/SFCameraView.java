package com.scanflow.datacapture.sfidcard;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.animation.AnimatorSet;
import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Color;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.SurfaceView;
import android.widget.FrameLayout;
import android.widget.ImageView;
import android.widget.TextView;
import androidx.camera.view.PreviewView;
import com.scanflow.datacapture.R;
import com.scanflow.ui.ar.ArOverlayView;

/* JADX INFO: loaded from: classes3.dex */
public class SFCameraView extends FrameLayout {
    private ArOverlayView arOverlayView;
    private ImageView img_card_flip;
    private Boolean isBorderCornersRounded;
    private Integer mBottomLeftColor;
    private Integer mBottomRightColor;
    private Integer mTopLeftColor;
    private Integer mTopRightColor;
    private PreviewView previewView;
    private SurfaceView surfaceView;
    private TextView textView;

    public SFCameraView(Context context) {
        super(context, null);
        this.isBorderCornersRounded = Boolean.FALSE;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
    }

    public void doFlipAnimation(Context context) {
        AnimatorSet animatorSet = (AnimatorSet) AnimatorInflater.loadAnimator(context, R.animator.flip);
        animatorSet.setTarget(this.img_card_flip);
        animatorSet.addListener(new Animator.AnimatorListener() { // from class: com.scanflow.datacapture.sfidcard.SFCameraView.1
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

    public SFCameraView(Context context, AttributeSet attributeSet) {
        super(context, attributeSet, 0);
        this.isBorderCornersRounded = Boolean.FALSE;
        this.mTopLeftColor = Integer.valueOf(Color.parseColor("#2256DE"));
        this.mTopRightColor = Integer.valueOf(Color.parseColor("#FF543E"));
        this.mBottomLeftColor = Integer.valueOf(Color.parseColor("#FFAF4D"));
        this.mBottomRightColor = Integer.valueOf(Color.parseColor("#3098F1"));
        this.previewView = new PreviewView(context, attributeSet);
        this.surfaceView = new SurfaceView(context, attributeSet);
        this.arOverlayView = new ArOverlayView(context, attributeSet);
        TypedArray typedArrayObtainStyledAttributes = context.obtainStyledAttributes(attributeSet, R.styleable.SFCameraView);
        this.isBorderCornersRounded = Boolean.valueOf(typedArrayObtainStyledAttributes.getBoolean(R.styleable.SFCameraView_roundedCorner, false));
        this.mTopLeftColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_topLeftCornerColor, Color.parseColor("#2256DE")));
        this.mTopRightColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_topRightCornerColor, Color.parseColor("#FF543E")));
        this.mBottomLeftColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_bottomLeftCornerColor, Color.parseColor("#FFAF4D")));
        this.mBottomRightColor = Integer.valueOf(typedArrayObtainStyledAttributes.getColor(R.styleable.SFCameraView_bottomRightCornerColor, Color.parseColor("#3098F1")));
        TextView textView = new TextView(context, attributeSet);
        this.textView = textView;
        textView.setGravity(17);
        this.textView.setTextSize(18.0f);
        this.textView.setPadding(20, 0, 20, 0);
        this.textView.setTextColor(Color.parseColor("#C0C0C0"));
        this.textView.setText("The Scanflow SDK licence validation failed. Your licence key has expired!");
        this.img_card_flip = new ImageView(context);
        int iApplyDimension = (int) TypedValue.applyDimension(2, 150.0f, getResources().getDisplayMetrics());
        int iApplyDimension2 = (int) TypedValue.applyDimension(2, 150.0f, getResources().getDisplayMetrics());
        this.img_card_flip.setImageResource(R.drawable.ic_flip_card);
        this.img_card_flip.setVisibility(8);
        FrameLayout.LayoutParams layoutParams = new FrameLayout.LayoutParams(iApplyDimension2, iApplyDimension, 17);
        FrameLayout.LayoutParams layoutParams2 = new FrameLayout.LayoutParams(-1, -1, 17);
        addView(this.previewView, layoutParams2);
        addView(this.surfaceView, layoutParams2);
        addView(this.arOverlayView, layoutParams2);
        addView(this.img_card_flip, layoutParams);
        addView(this.textView, layoutParams2);
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
    }
}
