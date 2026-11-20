package androidx.constraintlayout.core.state;

import androidx.constraintlayout.core.motion.CustomVariable;
import androidx.constraintlayout.core.motion.Motion;
import androidx.constraintlayout.core.motion.MotionWidget;
import androidx.constraintlayout.core.motion.key.MotionKeyAttributes;
import androidx.constraintlayout.core.motion.key.MotionKeyPosition;
import androidx.constraintlayout.core.motion.utils.KeyCache;
import androidx.constraintlayout.core.motion.utils.TypedBundle;
import androidx.constraintlayout.core.motion.utils.TypedValues;
import androidx.constraintlayout.core.state.Transition;
import androidx.constraintlayout.core.widgets.ConstraintWidget;
import androidx.constraintlayout.core.widgets.ConstraintWidgetContainer;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.key.MotionKeyCycle;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.Easing;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;

/* JADX INFO: loaded from: classes.dex */
public class Transition implements TypedValues {
    int mParentEndHeight;
    int mParentEndWidth;
    int mParentInterpolateHeight;
    int mParentInterpolatedWidth;
    int mParentStartHeight;
    int mParentStartWidth;
    final CorePixelDp mToPixel;
    boolean mWrap;
    private HashMap mKeyPositions = new HashMap();
    private HashMap mState = new HashMap();
    private TypedBundle mBundle = new TypedBundle();
    private int mDefaultInterpolator = 0;
    private String mDefaultInterpolatorString = null;
    private Easing mEasing = null;
    private int mAutoTransition = 0;
    private int mDuration = 400;
    private float mStagger = 0.0f;

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public int getId(String str) {
        return 0;
    }

    public float getTouchUpProgress(long j) {
        return 0.0f;
    }

    public boolean hasOnSwipe() {
        return false;
    }

    public boolean isFirstDownAccepted(float f, float f2) {
        return false;
    }

    public void setTouchUp(float f, long j, float f2, float f3) {
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, int i2) {
        return false;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, boolean z) {
        return false;
    }

    public Transition(CorePixelDp corePixelDp) {
        this.mToPixel = corePixelDp;
    }

    public float dragToProgress(float f, int i, int i2, float f2, float f3) {
        Iterator it = this.mState.values().iterator();
        WidgetState widgetState = it.hasNext() ? (WidgetState) it.next() : null;
        if (widgetState != null) {
            return (-f3) / widgetState.mParentHeight;
        }
        return 1.0f;
    }

    public boolean isTouchNotDone(float f) {
        throw null;
    }

    public static /* synthetic */ float $r8$lambda$OTLwiTr4Vkd6vYdlFgpIWtioYUc(String str, float f) {
        return (float) Easing.getInterpolator(str).get(f);
    }

    /* JADX INFO: renamed from: $r8$lambda$38HcK8E-UGajlUp8SBoCEbK9qzk, reason: not valid java name */
    public static /* synthetic */ float m71$r8$lambda$38HcK8EUGajlUp8SBoCEbK9qzk(float f) {
        return (float) Easing.getInterpolator("standard").get(f);
    }

    /* JADX INFO: renamed from: $r8$lambda$yfJrlI3baRN-7AsVJt1eO9DuLs4, reason: not valid java name */
    public static /* synthetic */ float m73$r8$lambda$yfJrlI3baRN7AsVJt1eO9DuLs4(float f) {
        return (float) Easing.getInterpolator("accelerate").get(f);
    }

    /* JADX INFO: renamed from: $r8$lambda$ksa-qRL3ckenFobo-pTBVPUly04, reason: not valid java name */
    public static /* synthetic */ float m72$r8$lambda$ksaqRL3ckenFobopTBVPUly04(float f) {
        return (float) Easing.getInterpolator("decelerate").get(f);
    }

    public static /* synthetic */ float $r8$lambda$fHs8COZdza9xPNtJb1s3jLavbvU(float f) {
        return (float) Easing.getInterpolator("linear").get(f);
    }

    public static /* synthetic */ float $r8$lambda$LHfHndAv9sefT8w3vOLiwBb6ASg(float f) {
        return (float) Easing.getInterpolator("anticipate").get(f);
    }

    public static Interpolator getInterpolator(int i, final String str) {
        switch (i) {
            case -1:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda0
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.$r8$lambda$OTLwiTr4Vkd6vYdlFgpIWtioYUc(str, f);
                    }
                };
            case 0:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda1
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.m71$r8$lambda$38HcK8EUGajlUp8SBoCEbK9qzk(f);
                    }
                };
            case 1:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda2
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.m73$r8$lambda$yfJrlI3baRN7AsVJt1eO9DuLs4(f);
                    }
                };
            case 2:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda3
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.m72$r8$lambda$ksaqRL3ckenFobopTBVPUly04(f);
                    }
                };
            case 3:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda4
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.$r8$lambda$fHs8COZdza9xPNtJb1s3jLavbvU(f);
                    }
                };
            case 4:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda7
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.$r8$lambda$7MCgQRsIQ1aRUh1CgxS4gHIyERI(f);
                    }
                };
            case 5:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda6
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.$r8$lambda$sE6FbSzaubjscYQbeMO2_QTROyA(f);
                    }
                };
            case 6:
                return new Interpolator() { // from class: com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.state.Transition$$ExternalSyntheticLambda5
                    @Override // androidx.constraintlayout.core.state.Interpolator
                    public final float getInterpolation(float f) {
                        return Transition.$r8$lambda$LHfHndAv9sefT8w3vOLiwBb6ASg(f);
                    }
                };
            default:
                return null;
        }
    }

    public static /* synthetic */ float $r8$lambda$sE6FbSzaubjscYQbeMO2_QTROyA(float f) {
        return (float) Easing.getInterpolator("overshoot").get(f);
    }

    public static /* synthetic */ float $r8$lambda$7MCgQRsIQ1aRUh1CgxS4gHIyERI(float f) {
        return (float) Easing.getInterpolator("spline(0.0, 0.2, 0.4, 0.6, 0.8 ,1.0, 0.8, 1.0, 0.9, 1.0)").get(f);
    }

    public KeyPosition findPreviousPosition(String str, int i) {
        KeyPosition keyPosition;
        while (i >= 0) {
            HashMap map = (HashMap) this.mKeyPositions.get(Integer.valueOf(i));
            if (map != null && (keyPosition = (KeyPosition) map.get(str)) != null) {
                return keyPosition;
            }
            i--;
        }
        return null;
    }

    public KeyPosition findNextPosition(String str, int i) {
        KeyPosition keyPosition;
        while (i <= 100) {
            HashMap map = (HashMap) this.mKeyPositions.get(Integer.valueOf(i));
            if (map != null && (keyPosition = (KeyPosition) map.get(str)) != null) {
                return keyPosition;
            }
            i++;
        }
        return null;
    }

    public int getNumberKeyPositions(WidgetFrame widgetFrame) {
        int i = 0;
        for (int i2 = 0; i2 <= 100; i2++) {
            HashMap map = (HashMap) this.mKeyPositions.get(Integer.valueOf(i2));
            if (map != null && ((KeyPosition) map.get(widgetFrame.widget.stringId)) != null) {
                i++;
            }
        }
        return i;
    }

    public Motion getMotion(String str) {
        return getWidgetState(str, null, 0).mMotionControl;
    }

    public void fillKeyPositions(WidgetFrame widgetFrame, float[] fArr, float[] fArr2, float[] fArr3) {
        KeyPosition keyPosition;
        int i = 0;
        for (int i2 = 0; i2 <= 100; i2++) {
            HashMap map = (HashMap) this.mKeyPositions.get(Integer.valueOf(i2));
            if (map != null && (keyPosition = (KeyPosition) map.get(widgetFrame.widget.stringId)) != null) {
                fArr[i] = keyPosition.mX;
                fArr2[i] = keyPosition.mY;
                fArr3[i] = keyPosition.mFrame;
                i++;
            }
        }
    }

    public boolean hasPositionKeyframes() {
        return this.mKeyPositions.size() > 0;
    }

    public void setTransitionProperties(TypedBundle typedBundle) {
        typedBundle.applyDelta(this.mBundle);
        typedBundle.applyDelta(this);
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, float f) {
        if (i != 706) {
            return false;
        }
        this.mStagger = f;
        return false;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, String str) {
        if (i != 705) {
            return false;
        }
        this.mDefaultInterpolatorString = str;
        this.mEasing = Easing.getInterpolator(str);
        return false;
    }

    public boolean isEmpty() {
        return this.mState.isEmpty();
    }

    public void clear() {
        this.mState.clear();
    }

    public boolean contains(String str) {
        return this.mState.containsKey(str);
    }

    public void addKeyPosition(String str, TypedBundle typedBundle) {
        getWidgetState(str, null, 0).setKeyPosition(typedBundle);
    }

    public void addKeyAttribute(String str, TypedBundle typedBundle) {
        getWidgetState(str, null, 0).setKeyAttribute(typedBundle);
    }

    public void addKeyAttribute(String str, TypedBundle typedBundle, CustomVariable[] customVariableArr) {
        getWidgetState(str, null, 0).setKeyAttribute(typedBundle, customVariableArr);
    }

    public void addKeyCycle(String str, TypedBundle typedBundle) {
        getWidgetState(str, null, 0).setKeyCycle(typedBundle);
    }

    public void addKeyPosition(String str, int i, int i2, float f, float f2) {
        TypedBundle typedBundle = new TypedBundle();
        typedBundle.add(510, 2);
        typedBundle.add(100, i);
        typedBundle.add(506, f);
        typedBundle.add(507, f2);
        getWidgetState(str, null, 0).setKeyPosition(typedBundle);
        KeyPosition keyPosition = new KeyPosition(str, i, i2, f, f2);
        HashMap map = (HashMap) this.mKeyPositions.get(Integer.valueOf(i));
        if (map == null) {
            map = new HashMap();
            this.mKeyPositions.put(Integer.valueOf(i), map);
        }
        map.put(str, keyPosition);
    }

    public void addCustomFloat(int i, String str, String str2, float f) {
        getWidgetState(str, null, i).getFrame(i).addCustomFloat(str2, f);
    }

    public void addCustomColor(int i, String str, String str2, int i2) {
        getWidgetState(str, null, i).getFrame(i).addCustomColor(str2, i2);
    }

    private void calculateParentDimensions(float f) {
        int i = this.mParentStartWidth;
        this.mParentInterpolatedWidth = (int) (i + 0.5f + ((this.mParentEndWidth - i) * f));
        int i2 = this.mParentStartHeight;
        this.mParentInterpolateHeight = (int) (i2 + 0.5f + ((this.mParentEndHeight - i2) * f));
    }

    public int getInterpolatedWidth() {
        return this.mParentInterpolatedWidth;
    }

    public int getInterpolatedHeight() {
        return this.mParentInterpolateHeight;
    }

    public void updateFrom(ConstraintWidgetContainer constraintWidgetContainer, int i) {
        ConstraintWidget.DimensionBehaviour[] dimensionBehaviourArr = constraintWidgetContainer.mListDimensionBehaviors;
        ConstraintWidget.DimensionBehaviour dimensionBehaviour = dimensionBehaviourArr[0];
        ConstraintWidget.DimensionBehaviour dimensionBehaviour2 = ConstraintWidget.DimensionBehaviour.WRAP_CONTENT;
        boolean z = dimensionBehaviour == dimensionBehaviour2;
        this.mWrap = z;
        this.mWrap = z | (dimensionBehaviourArr[1] == dimensionBehaviour2);
        if (i == 0) {
            int width = constraintWidgetContainer.getWidth();
            this.mParentStartWidth = width;
            this.mParentInterpolatedWidth = width;
            int height = constraintWidgetContainer.getHeight();
            this.mParentStartHeight = height;
            this.mParentInterpolateHeight = height;
        } else {
            this.mParentEndWidth = constraintWidgetContainer.getWidth();
            this.mParentEndHeight = constraintWidgetContainer.getHeight();
        }
        ArrayList<ConstraintWidget> children = constraintWidgetContainer.getChildren();
        int size = children.size();
        WidgetState[] widgetStateArr = new WidgetState[size];
        for (int i2 = 0; i2 < size; i2++) {
            ConstraintWidget constraintWidget = children.get(i2);
            WidgetState widgetState = getWidgetState(constraintWidget.stringId, null, i);
            widgetStateArr[i2] = widgetState;
            widgetState.update(constraintWidget, i);
            String pathRelativeId = widgetState.getPathRelativeId();
            if (pathRelativeId != null) {
                widgetState.setPathRelative(getWidgetState(pathRelativeId, null, i));
            }
        }
        calcStagger();
    }

    public void interpolate(int i, int i2, float f) {
        if (this.mWrap) {
            calculateParentDimensions(f);
        }
        Easing easing = this.mEasing;
        if (easing != null) {
            f = (float) easing.get(f);
        }
        Iterator it = this.mState.keySet().iterator();
        while (it.hasNext()) {
            ((WidgetState) this.mState.get((String) it.next())).interpolate(i, i2, f, this);
        }
    }

    public WidgetFrame getStart(String str) {
        WidgetState widgetState = (WidgetState) this.mState.get(str);
        if (widgetState == null) {
            return null;
        }
        return widgetState.mStart;
    }

    public WidgetFrame getEnd(String str) {
        WidgetState widgetState = (WidgetState) this.mState.get(str);
        if (widgetState == null) {
            return null;
        }
        return widgetState.mEnd;
    }

    public WidgetFrame getInterpolated(String str) {
        WidgetState widgetState = (WidgetState) this.mState.get(str);
        if (widgetState == null) {
            return null;
        }
        return widgetState.mInterpolated;
    }

    public float[] getPath(String str) {
        float[] fArr = new float[124];
        ((WidgetState) this.mState.get(str)).mMotionControl.buildPath(fArr, 62);
        return fArr;
    }

    public int getKeyFrames(String str, float[] fArr, int[] iArr, int[] iArr2) {
        return ((WidgetState) this.mState.get(str)).mMotionControl.buildKeyFrames(fArr, iArr, iArr2);
    }

    private WidgetState getWidgetState(String str) {
        return (WidgetState) this.mState.get(str);
    }

    public WidgetState getWidgetState(String str, ConstraintWidget constraintWidget, int i) {
        WidgetState widgetState = (WidgetState) this.mState.get(str);
        if (widgetState == null) {
            widgetState = new WidgetState();
            this.mBundle.applyDelta(widgetState.mMotionControl);
            widgetState.mMotionWidgetStart.updateMotion(widgetState.mMotionControl);
            this.mState.put(str, widgetState);
            if (constraintWidget != null) {
                widgetState.update(constraintWidget, i);
            }
        }
        return widgetState;
    }

    public WidgetFrame getStart(ConstraintWidget constraintWidget) {
        return getWidgetState(constraintWidget.stringId, null, 0).mStart;
    }

    public WidgetFrame getEnd(ConstraintWidget constraintWidget) {
        return getWidgetState(constraintWidget.stringId, null, 1).mEnd;
    }

    public WidgetFrame getInterpolated(ConstraintWidget constraintWidget) {
        return getWidgetState(constraintWidget.stringId, null, 2).mInterpolated;
    }

    public Interpolator getInterpolator() {
        return getInterpolator(this.mDefaultInterpolator, this.mDefaultInterpolatorString);
    }

    public int getAutoTransition() {
        return this.mAutoTransition;
    }

    public static class WidgetState {
        Motion mMotionControl;
        boolean mNeedSetup = true;
        KeyCache mKeyCache = new KeyCache();
        int mParentHeight = -1;
        int mParentWidth = -1;
        WidgetFrame mStart = new WidgetFrame();
        WidgetFrame mEnd = new WidgetFrame();
        WidgetFrame mInterpolated = new WidgetFrame();
        MotionWidget mMotionWidgetStart = new MotionWidget(this.mStart);
        MotionWidget mMotionWidgetEnd = new MotionWidget(this.mEnd);
        MotionWidget mMotionWidgetInterpolated = new MotionWidget(this.mInterpolated);

        public WidgetState() {
            Motion motion = new Motion(this.mMotionWidgetStart);
            this.mMotionControl = motion;
            motion.setStart(this.mMotionWidgetStart);
            this.mMotionControl.setEnd(this.mMotionWidgetEnd);
        }

        public void setKeyPosition(TypedBundle typedBundle) {
            MotionKeyPosition motionKeyPosition = new MotionKeyPosition();
            typedBundle.applyDelta(motionKeyPosition);
            this.mMotionControl.addKey(motionKeyPosition);
        }

        public void setKeyAttribute(TypedBundle typedBundle) {
            MotionKeyAttributes motionKeyAttributes = new MotionKeyAttributes();
            typedBundle.applyDelta(motionKeyAttributes);
            this.mMotionControl.addKey(motionKeyAttributes);
        }

        public void setKeyAttribute(TypedBundle typedBundle, CustomVariable[] customVariableArr) {
            MotionKeyAttributes motionKeyAttributes = new MotionKeyAttributes();
            typedBundle.applyDelta(motionKeyAttributes);
            if (customVariableArr != null) {
                for (int i = 0; i < customVariableArr.length; i++) {
                    motionKeyAttributes.mCustom.put(customVariableArr[i].getName(), customVariableArr[i]);
                }
            }
            this.mMotionControl.addKey(motionKeyAttributes);
        }

        public void setKeyCycle(TypedBundle typedBundle) {
            MotionKeyCycle motionKeyCycle = new MotionKeyCycle();
            typedBundle.applyDelta(motionKeyCycle);
            this.mMotionControl.addKey(motionKeyCycle);
        }

        /* JADX WARN: Type inference fix 'apply assigned field type' failed
        java.lang.UnsupportedOperationException: ArgType.getObject(), call class: class jadx.core.dex.instructions.args.ArgType$UnknownArg
        	at jadx.core.dex.instructions.args.ArgType.getObject(ArgType.java:596)
        	at jadx.core.dex.attributes.nodes.ClassTypeVarsAttr.getTypeVarsMapFor(ClassTypeVarsAttr.java:35)
        	at jadx.core.dex.nodes.utils.TypeUtils.replaceClassGenerics(TypeUtils.java:177)
        	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.insertExplicitUseCast(FixTypesVisitor.java:397)
        	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.tryFieldTypeWithNewCasts(FixTypesVisitor.java:359)
        	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.applyFieldType(FixTypesVisitor.java:309)
        	at jadx.core.dex.visitors.typeinference.FixTypesVisitor.visit(FixTypesVisitor.java:94)
         */
        public void update(ConstraintWidget constraintWidget, int i) {
            if (i == 0) {
                this.mStart.update(constraintWidget);
                MotionWidget motionWidget = this.mMotionWidgetStart;
                motionWidget.updateMotion(motionWidget);
                this.mMotionControl.setStart(this.mMotionWidgetStart);
                this.mNeedSetup = true;
            } else if (i == 1) {
                this.mEnd.update(constraintWidget);
                this.mMotionControl.setEnd(this.mMotionWidgetEnd);
                this.mNeedSetup = true;
            }
            this.mParentWidth = -1;
        }

        String getPathRelativeId() {
            return this.mMotionControl.getAnimateRelativeTo();
        }

        public WidgetFrame getFrame(int i) {
            if (i == 0) {
                return this.mStart;
            }
            if (i == 1) {
                return this.mEnd;
            }
            return this.mInterpolated;
        }

        public void interpolate(int i, int i2, float f, Transition transition) {
            this.mParentHeight = i2;
            this.mParentWidth = i;
            if (this.mNeedSetup) {
                this.mMotionControl.setup(i, i2, 1.0f, System.nanoTime());
                this.mNeedSetup = false;
            }
            WidgetFrame.interpolate(i, i2, this.mInterpolated, this.mStart, this.mEnd, transition, f);
            this.mInterpolated.interpolatedPos = f;
            this.mMotionControl.interpolate(this.mMotionWidgetInterpolated, f, System.nanoTime(), this.mKeyCache);
        }

        public void setPathRelative(WidgetState widgetState) {
            this.mMotionControl.setupRelative(widgetState.mMotionControl);
        }
    }

    static class KeyPosition {
        int mFrame;
        String mTarget;
        int mType;
        float mX;
        float mY;

        KeyPosition(String str, int i, int i2, float f, float f2) {
            this.mTarget = str;
            this.mFrame = i;
            this.mType = i2;
            this.mX = f;
            this.mY = f2;
        }
    }

    public void calcStagger() {
        float fMin;
        float fMax;
        float f = this.mStagger;
        if (f == 0.0f) {
            return;
        }
        boolean z = ((double) f) < 0.0d;
        float fAbs = Math.abs(f);
        Iterator it = this.mState.keySet().iterator();
        do {
            fMin = Float.MAX_VALUE;
            fMax = -3.4028235E38f;
            if (!it.hasNext()) {
                Iterator it2 = this.mState.keySet().iterator();
                while (it2.hasNext()) {
                    Motion motion = ((WidgetState) this.mState.get((String) it2.next())).mMotionControl;
                    float finalX = motion.getFinalX() + motion.getFinalY();
                    fMin = Math.min(fMin, finalX);
                    fMax = Math.max(fMax, finalX);
                }
                Iterator it3 = this.mState.keySet().iterator();
                while (it3.hasNext()) {
                    Motion motion2 = ((WidgetState) this.mState.get((String) it3.next())).mMotionControl;
                    float finalX2 = motion2.getFinalX() + motion2.getFinalY();
                    float f2 = fMax - fMin;
                    float f3 = fAbs - (((finalX2 - fMin) * fAbs) / f2);
                    if (z) {
                        f3 = fAbs - (((fMax - finalX2) / f2) * fAbs);
                    }
                    motion2.setStaggerScale(1.0f / (1.0f - fAbs));
                    motion2.setStaggerOffset(f3);
                }
                return;
            }
        } while (Float.isNaN(((WidgetState) this.mState.get((String) it.next())).mMotionControl.getMotionStagger()));
        Iterator it4 = this.mState.keySet().iterator();
        while (it4.hasNext()) {
            float motionStagger = ((WidgetState) this.mState.get((String) it4.next())).mMotionControl.getMotionStagger();
            if (!Float.isNaN(motionStagger)) {
                fMin = Math.min(fMin, motionStagger);
                fMax = Math.max(fMax, motionStagger);
            }
        }
        Iterator it5 = this.mState.keySet().iterator();
        while (it5.hasNext()) {
            Motion motion3 = ((WidgetState) this.mState.get((String) it5.next())).mMotionControl;
            float motionStagger2 = motion3.getMotionStagger();
            if (!Float.isNaN(motionStagger2)) {
                float f4 = 1.0f / (1.0f - fAbs);
                float f5 = fMax - fMin;
                float f6 = fAbs - (((motionStagger2 - fMin) * fAbs) / f5);
                if (z) {
                    f6 = fAbs - (((fMax - motionStagger2) / f5) * fAbs);
                }
                motion3.setStaggerScale(f4);
                motion3.setStaggerOffset(f6);
            }
        }
    }
}
