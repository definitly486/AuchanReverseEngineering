package androidx.constraintlayout.core.motion.key;

import androidx.constraintlayout.core.motion.CustomVariable;
import androidx.constraintlayout.core.motion.utils.SplineSet;
import androidx.constraintlayout.core.motion.utils.TypedValues;
import java.util.HashMap;
import java.util.HashSet;

/* JADX INFO: loaded from: classes.dex */
public abstract class MotionKey implements TypedValues {
    public static int UNSET = -1;
    public HashMap mCustom;
    public int mFramePosition;
    int mTargetId;
    String mTargetString;
    public int mType;

    public abstract void addValues(HashMap<String, SplineSet> map);

    @Override // 
    /* JADX INFO: renamed from: clone, reason: merged with bridge method [inline-methods] */
    public abstract MotionKey mo69clone();

    public abstract void getAttributeNames(HashSet<String> hashSet);

    public void setInterpolation(HashMap<String, Integer> map) {
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, float f) {
        return false;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, boolean z) {
        return false;
    }

    public MotionKey() {
        int i = UNSET;
        this.mFramePosition = i;
        this.mTargetId = i;
        this.mTargetString = null;
    }

    public MotionKey copy(MotionKey motionKey) {
        this.mFramePosition = motionKey.mFramePosition;
        this.mTargetId = motionKey.mTargetId;
        this.mTargetString = motionKey.mTargetString;
        this.mType = motionKey.mType;
        return this;
    }

    public MotionKey setViewId(int i) {
        this.mTargetId = i;
        return this;
    }

    public void setFramePosition(int i) {
        this.mFramePosition = i;
    }

    public int getFramePosition() {
        return this.mFramePosition;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, int i2) {
        if (i != 100) {
            return false;
        }
        this.mFramePosition = i2;
        return true;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, String str) {
        if (i != 101) {
            return false;
        }
        this.mTargetString = str;
        return true;
    }

    public void setCustomAttribute(String str, int i, float f) {
        this.mCustom.put(str, new CustomVariable(str, i, f));
    }

    public void setCustomAttribute(String str, int i, int i2) {
        this.mCustom.put(str, new CustomVariable(str, i, i2));
    }

    public void setCustomAttribute(String str, int i, boolean z) {
        this.mCustom.put(str, new CustomVariable(str, i, z));
    }

    public void setCustomAttribute(String str, int i, String str2) {
        this.mCustom.put(str, new CustomVariable(str, i, str2));
    }
}
