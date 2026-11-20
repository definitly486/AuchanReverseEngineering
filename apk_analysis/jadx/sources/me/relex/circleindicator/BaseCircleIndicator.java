package me.relex.circleindicator;

import android.animation.Animator;
import android.animation.AnimatorInflater;
import android.content.Context;
import android.content.res.TypedArray;
import android.util.AttributeSet;
import android.util.TypedValue;
import android.view.View;
import android.view.animation.Interpolator;
import android.widget.LinearLayout;

/* JADX INFO: loaded from: classes3.dex */
class BaseCircleIndicator extends LinearLayout {
    protected Animator mAnimatorIn;
    protected Animator mAnimatorOut;
    protected Animator mImmediateAnimatorIn;
    protected Animator mImmediateAnimatorOut;
    protected int mIndicatorBackgroundResId;
    protected int mIndicatorHeight;
    protected int mIndicatorMargin;
    protected int mIndicatorUnselectedBackgroundResId;
    protected int mIndicatorWidth;
    protected int mLastPosition;

    public interface IndicatorCreatedListener {
    }

    public void setIndicatorCreatedListener(IndicatorCreatedListener indicatorCreatedListener) {
    }

    public BaseCircleIndicator(Context context) {
        super(context);
        this.mIndicatorMargin = -1;
        this.mIndicatorWidth = -1;
        this.mIndicatorHeight = -1;
        this.mLastPosition = -1;
        init(context, null);
    }

    public BaseCircleIndicator(Context context, AttributeSet attributeSet) {
        super(context, attributeSet);
        this.mIndicatorMargin = -1;
        this.mIndicatorWidth = -1;
        this.mIndicatorHeight = -1;
        this.mLastPosition = -1;
        init(context, attributeSet);
    }

    public BaseCircleIndicator(Context context, AttributeSet attributeSet, int i) {
        super(context, attributeSet, i);
        this.mIndicatorMargin = -1;
        this.mIndicatorWidth = -1;
        this.mIndicatorHeight = -1;
        this.mLastPosition = -1;
        init(context, attributeSet);
    }

    public BaseCircleIndicator(Context context, AttributeSet attributeSet, int i, int i2) {
        super(context, attributeSet, i, i2);
        this.mIndicatorMargin = -1;
        this.mIndicatorWidth = -1;
        this.mIndicatorHeight = -1;
        this.mLastPosition = -1;
        init(context, attributeSet);
    }

    private void init(Context context, AttributeSet attributeSet) {
        initialize(handleTypedArray(context, attributeSet));
    }

    private Config handleTypedArray(Context context, AttributeSet attributeSet) {
        Config config = new Config();
        if (attributeSet == null) {
            return config;
        }
        TypedArray typedArrayObtainStyledAttributes = context.obtainStyledAttributes(attributeSet, R$styleable.BaseCircleIndicator);
        config.width = typedArrayObtainStyledAttributes.getDimensionPixelSize(R$styleable.BaseCircleIndicator_ci_width, -1);
        config.height = typedArrayObtainStyledAttributes.getDimensionPixelSize(R$styleable.BaseCircleIndicator_ci_height, -1);
        config.margin = typedArrayObtainStyledAttributes.getDimensionPixelSize(R$styleable.BaseCircleIndicator_ci_margin, -1);
        config.animatorResId = typedArrayObtainStyledAttributes.getResourceId(R$styleable.BaseCircleIndicator_ci_animator, R$animator.scale_with_alpha);
        config.animatorReverseResId = typedArrayObtainStyledAttributes.getResourceId(R$styleable.BaseCircleIndicator_ci_animator_reverse, 0);
        int resourceId = typedArrayObtainStyledAttributes.getResourceId(R$styleable.BaseCircleIndicator_ci_drawable, R$drawable.white_radius);
        config.backgroundResId = resourceId;
        config.unselectedBackgroundId = typedArrayObtainStyledAttributes.getResourceId(R$styleable.BaseCircleIndicator_ci_drawable_unselected, resourceId);
        config.orientation = typedArrayObtainStyledAttributes.getInt(R$styleable.BaseCircleIndicator_ci_orientation, -1);
        config.gravity = typedArrayObtainStyledAttributes.getInt(R$styleable.BaseCircleIndicator_ci_gravity, -1);
        typedArrayObtainStyledAttributes.recycle();
        return config;
    }

    public void initialize(Config config) {
        int iApplyDimension = (int) (TypedValue.applyDimension(1, 5.0f, getResources().getDisplayMetrics()) + 0.5f);
        int i = config.width;
        if (i < 0) {
            i = iApplyDimension;
        }
        this.mIndicatorWidth = i;
        int i2 = config.height;
        if (i2 < 0) {
            i2 = iApplyDimension;
        }
        this.mIndicatorHeight = i2;
        int i3 = config.margin;
        if (i3 >= 0) {
            iApplyDimension = i3;
        }
        this.mIndicatorMargin = iApplyDimension;
        this.mAnimatorOut = createAnimatorOut(config);
        Animator animatorCreateAnimatorOut = createAnimatorOut(config);
        this.mImmediateAnimatorOut = animatorCreateAnimatorOut;
        animatorCreateAnimatorOut.setDuration(0L);
        this.mAnimatorIn = createAnimatorIn(config);
        Animator animatorCreateAnimatorIn = createAnimatorIn(config);
        this.mImmediateAnimatorIn = animatorCreateAnimatorIn;
        animatorCreateAnimatorIn.setDuration(0L);
        int i4 = config.backgroundResId;
        this.mIndicatorBackgroundResId = i4 == 0 ? R$drawable.white_radius : i4;
        int i5 = config.unselectedBackgroundId;
        if (i5 != 0) {
            i4 = i5;
        }
        this.mIndicatorUnselectedBackgroundResId = i4;
        setOrientation(config.orientation != 1 ? 0 : 1);
        int i6 = config.gravity;
        if (i6 < 0) {
            i6 = 17;
        }
        setGravity(i6);
    }

    protected Animator createAnimatorOut(Config config) {
        return AnimatorInflater.loadAnimator(getContext(), config.animatorResId);
    }

    protected Animator createAnimatorIn(Config config) {
        if (config.animatorReverseResId == 0) {
            Animator animatorLoadAnimator = AnimatorInflater.loadAnimator(getContext(), config.animatorResId);
            animatorLoadAnimator.setInterpolator(new ReverseInterpolator());
            return animatorLoadAnimator;
        }
        return AnimatorInflater.loadAnimator(getContext(), config.animatorReverseResId);
    }

    public void createIndicators(int i, int i2) {
        if (this.mImmediateAnimatorOut.isRunning()) {
            this.mImmediateAnimatorOut.end();
            this.mImmediateAnimatorOut.cancel();
        }
        if (this.mImmediateAnimatorIn.isRunning()) {
            this.mImmediateAnimatorIn.end();
            this.mImmediateAnimatorIn.cancel();
        }
        int childCount = getChildCount();
        if (i < childCount) {
            removeViews(i, childCount - i);
        } else if (i > childCount) {
            int i3 = i - childCount;
            int orientation = getOrientation();
            for (int i4 = 0; i4 < i3; i4++) {
                addIndicator(orientation);
            }
        }
        for (int i5 = 0; i5 < i; i5++) {
            View childAt = getChildAt(i5);
            if (i2 == i5) {
                childAt.setBackgroundResource(this.mIndicatorBackgroundResId);
                this.mImmediateAnimatorOut.setTarget(childAt);
                this.mImmediateAnimatorOut.start();
                this.mImmediateAnimatorOut.end();
            } else {
                childAt.setBackgroundResource(this.mIndicatorUnselectedBackgroundResId);
                this.mImmediateAnimatorIn.setTarget(childAt);
                this.mImmediateAnimatorIn.start();
                this.mImmediateAnimatorIn.end();
            }
        }
        this.mLastPosition = i2;
    }

    protected void addIndicator(int i) {
        View view = new View(getContext());
        LinearLayout.LayoutParams layoutParamsGenerateDefaultLayoutParams = generateDefaultLayoutParams();
        layoutParamsGenerateDefaultLayoutParams.width = this.mIndicatorWidth;
        layoutParamsGenerateDefaultLayoutParams.height = this.mIndicatorHeight;
        if (i == 0) {
            int i2 = this.mIndicatorMargin;
            layoutParamsGenerateDefaultLayoutParams.leftMargin = i2;
            layoutParamsGenerateDefaultLayoutParams.rightMargin = i2;
        } else {
            int i3 = this.mIndicatorMargin;
            layoutParamsGenerateDefaultLayoutParams.topMargin = i3;
            layoutParamsGenerateDefaultLayoutParams.bottomMargin = i3;
        }
        addView(view, layoutParamsGenerateDefaultLayoutParams);
    }

    public void animatePageSelected(int i) {
        View childAt;
        if (this.mLastPosition == i) {
            return;
        }
        if (this.mAnimatorIn.isRunning()) {
            this.mAnimatorIn.end();
            this.mAnimatorIn.cancel();
        }
        if (this.mAnimatorOut.isRunning()) {
            this.mAnimatorOut.end();
            this.mAnimatorOut.cancel();
        }
        int i2 = this.mLastPosition;
        if (i2 >= 0 && (childAt = getChildAt(i2)) != null) {
            childAt.setBackgroundResource(this.mIndicatorUnselectedBackgroundResId);
            this.mAnimatorIn.setTarget(childAt);
            this.mAnimatorIn.start();
        }
        View childAt2 = getChildAt(i);
        if (childAt2 != null) {
            childAt2.setBackgroundResource(this.mIndicatorBackgroundResId);
            this.mAnimatorOut.setTarget(childAt2);
            this.mAnimatorOut.start();
        }
        this.mLastPosition = i;
    }

    protected class ReverseInterpolator implements Interpolator {
        protected ReverseInterpolator() {
        }

        @Override // android.animation.TimeInterpolator
        public float getInterpolation(float f) {
            return Math.abs(1.0f - f);
        }
    }
}
