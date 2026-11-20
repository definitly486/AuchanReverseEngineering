package androidx.appcompat.widget;

import android.content.Context;
import android.content.res.ColorStateList;
import android.content.res.Resources;
import android.graphics.PorterDuff;
import android.graphics.drawable.Drawable;
import android.util.AttributeSet;
import android.widget.CheckedTextView;
import androidx.appcompat.content.res.AppCompatResources;
import androidx.core.view.ViewCompat;
import androidx.core.widget.CheckedTextViewCompat;
import com.scanflow.datacapture.barinternal.androidx.appcompat.R$styleable;
import com.scanflow.datacapture.barinternal.androidx.core.graphics.drawable.DrawableCompat;

/* JADX INFO: loaded from: classes.dex */
class AppCompatCheckedTextViewHelper {
    private ColorStateList mCheckMarkTintList = null;
    private PorterDuff.Mode mCheckMarkTintMode = null;
    private boolean mHasCheckMarkTint = false;
    private boolean mHasCheckMarkTintMode = false;
    private boolean mSkipNextApply;
    private final CheckedTextView mView;

    AppCompatCheckedTextViewHelper(CheckedTextView checkedTextView) {
        this.mView = checkedTextView;
    }

    void loadFromAttributes(AttributeSet attributeSet, int i) {
        int i2;
        int resourceId;
        int resourceId2;
        Context context = this.mView.getContext();
        int[] iArr = R$styleable.CheckedTextView;
        TintTypedArray tintTypedArrayObtainStyledAttributes = TintTypedArray.obtainStyledAttributes(context, attributeSet, iArr, i, 0);
        CheckedTextView checkedTextView = this.mView;
        ViewCompat.saveAttributeDataForStyleable(checkedTextView, checkedTextView.getContext(), iArr, attributeSet, tintTypedArrayObtainStyledAttributes.getWrappedTypeArray(), i, 0);
        try {
            int i3 = R$styleable.CheckedTextView_checkMarkCompat;
            if (tintTypedArrayObtainStyledAttributes.hasValue(i3) && (resourceId2 = tintTypedArrayObtainStyledAttributes.getResourceId(i3, 0)) != 0) {
                try {
                    CheckedTextView checkedTextView2 = this.mView;
                    checkedTextView2.setCheckMarkDrawable(AppCompatResources.getDrawable(checkedTextView2.getContext(), resourceId2));
                } catch (Resources.NotFoundException unused) {
                    i2 = R$styleable.CheckedTextView_android_checkMark;
                    if (tintTypedArrayObtainStyledAttributes.hasValue(i2)) {
                        CheckedTextView checkedTextView3 = this.mView;
                        checkedTextView3.setCheckMarkDrawable(AppCompatResources.getDrawable(checkedTextView3.getContext(), resourceId));
                    }
                }
            } else {
                i2 = R$styleable.CheckedTextView_android_checkMark;
                if (tintTypedArrayObtainStyledAttributes.hasValue(i2) && (resourceId = tintTypedArrayObtainStyledAttributes.getResourceId(i2, 0)) != 0) {
                    CheckedTextView checkedTextView4 = this.mView;
                    checkedTextView4.setCheckMarkDrawable(AppCompatResources.getDrawable(checkedTextView4.getContext(), resourceId));
                }
            }
            int i4 = R$styleable.CheckedTextView_checkMarkTint;
            if (tintTypedArrayObtainStyledAttributes.hasValue(i4)) {
                CheckedTextViewCompat.setCheckMarkTintList(this.mView, tintTypedArrayObtainStyledAttributes.getColorStateList(i4));
            }
            int i5 = R$styleable.CheckedTextView_checkMarkTintMode;
            if (tintTypedArrayObtainStyledAttributes.hasValue(i5)) {
                CheckedTextViewCompat.setCheckMarkTintMode(this.mView, DrawableUtils.parseTintMode(tintTypedArrayObtainStyledAttributes.getInt(i5, -1), null));
            }
        } finally {
            tintTypedArrayObtainStyledAttributes.recycle();
        }
    }

    void setSupportCheckMarkTintList(ColorStateList colorStateList) {
        this.mCheckMarkTintList = colorStateList;
        this.mHasCheckMarkTint = true;
        applyCheckMarkTint();
    }

    ColorStateList getSupportCheckMarkTintList() {
        return this.mCheckMarkTintList;
    }

    void setSupportCheckMarkTintMode(PorterDuff.Mode mode) {
        this.mCheckMarkTintMode = mode;
        this.mHasCheckMarkTintMode = true;
        applyCheckMarkTint();
    }

    PorterDuff.Mode getSupportCheckMarkTintMode() {
        return this.mCheckMarkTintMode;
    }

    void onSetCheckMarkDrawable() {
        if (this.mSkipNextApply) {
            this.mSkipNextApply = false;
        } else {
            this.mSkipNextApply = true;
            applyCheckMarkTint();
        }
    }

    void applyCheckMarkTint() {
        Drawable checkMarkDrawable = CheckedTextViewCompat.getCheckMarkDrawable(this.mView);
        if (checkMarkDrawable != null) {
            if (this.mHasCheckMarkTint || this.mHasCheckMarkTintMode) {
                Drawable drawableMutate = DrawableCompat.wrap(checkMarkDrawable).mutate();
                if (this.mHasCheckMarkTint) {
                    DrawableCompat.setTintList(drawableMutate, this.mCheckMarkTintList);
                }
                if (this.mHasCheckMarkTintMode) {
                    DrawableCompat.setTintMode(drawableMutate, this.mCheckMarkTintMode);
                }
                if (drawableMutate.isStateful()) {
                    drawableMutate.setState(this.mView.getDrawableState());
                }
                this.mView.setCheckMarkDrawable(drawableMutate);
            }
        }
    }
}
