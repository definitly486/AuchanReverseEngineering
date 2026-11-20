package androidx.constraintlayout.core.motion;

import androidx.constraintlayout.core.motion.key.MotionKey;
import androidx.constraintlayout.core.motion.key.MotionKeyAttributes;
import androidx.constraintlayout.core.motion.key.MotionKeyPosition;
import androidx.constraintlayout.core.motion.utils.CurveFit;
import androidx.constraintlayout.core.motion.utils.KeyCache;
import androidx.constraintlayout.core.motion.utils.KeyCycleOscillator;
import androidx.constraintlayout.core.motion.utils.KeyFrameArray;
import androidx.constraintlayout.core.motion.utils.SplineSet;
import androidx.constraintlayout.core.motion.utils.TypedBundle;
import androidx.constraintlayout.core.motion.utils.TypedValues;
import androidx.constraintlayout.core.motion.utils.ViewState;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.key.MotionKeyCycle;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.key.MotionKeyTrigger;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.DifferentialInterpolator;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.Easing;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.Rect;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.TimeCycleSplineSet;
import com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.Utils;
import io.appmetrica.analytics.coreutils.internal.StringUtils;
import java.lang.reflect.Array;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Collections;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;

/* JADX INFO: loaded from: classes.dex */
public class Motion implements TypedValues {
    private CurveFit mArcSpline;
    private int[] mAttributeInterpolatorCount;
    private String[] mAttributeNames;
    private HashMap mAttributesMap;
    float mCurrentCenterX;
    float mCurrentCenterY;
    private HashMap mCycleMap;
    public String mId;
    private double[] mInterpolateData;
    private int[] mInterpolateVariables;
    private double[] mInterpolateVelocity;
    private MotionKeyTrigger[] mKeyTriggers;
    Motion mRelativeMotion;
    private CurveFit[] mSpline;
    private HashMap mTimeCycleAttributesMap;
    MotionWidget mView;
    Rect mTempRect = new Rect();
    private int mCurveFitType = 0;
    private MotionPaths mStartMotionPath = new MotionPaths();
    private MotionPaths mEndMotionPath = new MotionPaths();
    private MotionConstrainedPoint mStartPoint = new MotionConstrainedPoint();
    private MotionConstrainedPoint mEndPoint = new MotionConstrainedPoint();
    float mMotionStagger = Float.NaN;
    float mStaggerOffset = 0.0f;
    float mStaggerScale = 1.0f;
    private int mMaxDimension = 4;
    private float[] mValuesBuff = new float[4];
    private ArrayList mMotionPaths = new ArrayList();
    private float[] mVelocity = new float[1];
    private ArrayList mKeyList = new ArrayList();
    private int mPathMotionArc = -1;
    private int mTransformPivotTarget = -1;
    private MotionWidget mTransformPivotView = null;
    private int mQuantizeMotionSteps = -1;
    private float mQuantizeMotionPhase = Float.NaN;
    private DifferentialInterpolator mQuantizeMotionInterpolator = null;
    private boolean mNoMovement = false;

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public int getId(String str) {
        return 0;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, boolean z) {
        return false;
    }

    public int getTransformPivotTarget() {
        return this.mTransformPivotTarget;
    }

    public void setTransformPivotTarget(int i) {
        this.mTransformPivotTarget = i;
        this.mTransformPivotView = null;
    }

    public MotionPaths getKeyFrame(int i) {
        return (MotionPaths) this.mMotionPaths.get(i);
    }

    public Motion(MotionWidget motionWidget) {
        setView(motionWidget);
    }

    public float getStartX() {
        return this.mStartMotionPath.mX;
    }

    public float getStartY() {
        return this.mStartMotionPath.mY;
    }

    public float getFinalX() {
        return this.mEndMotionPath.mX;
    }

    public float getFinalY() {
        return this.mEndMotionPath.mY;
    }

    public float getStartWidth() {
        return this.mStartMotionPath.mWidth;
    }

    public float getStartHeight() {
        return this.mStartMotionPath.mHeight;
    }

    public float getFinalWidth() {
        return this.mEndMotionPath.mWidth;
    }

    public float getFinalHeight() {
        return this.mEndMotionPath.mHeight;
    }

    public String getAnimateRelativeTo() {
        return this.mStartMotionPath.mAnimateRelativeTo;
    }

    public void setupRelative(Motion motion) {
        this.mRelativeMotion = motion;
    }

    private void setupRelative() {
        Motion motion = this.mRelativeMotion;
        if (motion == null) {
            return;
        }
        this.mStartMotionPath.setupRelative(motion, motion.mStartMotionPath);
        MotionPaths motionPaths = this.mEndMotionPath;
        Motion motion2 = this.mRelativeMotion;
        motionPaths.setupRelative(motion2, motion2.mEndMotionPath);
    }

    public float getCenterX() {
        return this.mCurrentCenterX;
    }

    public float getCenterY() {
        return this.mCurrentCenterY;
    }

    public void getCenter(double d, float[] fArr, float[] fArr2) {
        double[] dArr = new double[4];
        double[] dArr2 = new double[4];
        this.mSpline[0].getPos(d, dArr);
        this.mSpline[0].getSlope(d, dArr2);
        Arrays.fill(fArr2, 0.0f);
        this.mStartMotionPath.getCenter(d, this.mInterpolateVariables, dArr, fArr, dArr2, fArr2);
    }

    public void buildPath(float[] fArr, int i) {
        int i2 = i;
        float f = 1.0f;
        float f2 = 1.0f / (i2 - 1);
        HashMap map = this.mAttributesMap;
        SplineSet splineSet = map == null ? null : (SplineSet) map.get("translationX");
        HashMap map2 = this.mAttributesMap;
        SplineSet splineSet2 = map2 == null ? null : (SplineSet) map2.get("translationY");
        HashMap map3 = this.mCycleMap;
        KeyCycleOscillator keyCycleOscillator = map3 == null ? null : (KeyCycleOscillator) map3.get("translationX");
        HashMap map4 = this.mCycleMap;
        KeyCycleOscillator keyCycleOscillator2 = map4 != null ? (KeyCycleOscillator) map4.get("translationY") : null;
        int i3 = 0;
        while (i3 < i2) {
            float fMin = i3 * f2;
            float f3 = this.mStaggerScale;
            float f4 = 0.0f;
            if (f3 != f) {
                float f5 = this.mStaggerOffset;
                if (fMin < f5) {
                    fMin = 0.0f;
                }
                if (fMin > f5 && fMin < 1.0d) {
                    fMin = Math.min((fMin - f5) * f3, f);
                }
            }
            double d = fMin;
            Easing easing = this.mStartMotionPath.mKeyFrameEasing;
            ArrayList arrayList = this.mMotionPaths;
            int size = arrayList.size();
            float f6 = Float.NaN;
            int i4 = 0;
            while (i4 < size) {
                Object obj = arrayList.get(i4);
                i4++;
                MotionPaths motionPaths = (MotionPaths) obj;
                float f7 = f2;
                Easing easing2 = motionPaths.mKeyFrameEasing;
                if (easing2 != null) {
                    float f8 = motionPaths.mTime;
                    if (f8 < fMin) {
                        f4 = f8;
                        easing = easing2;
                    } else if (Float.isNaN(f6)) {
                        f6 = motionPaths.mTime;
                    }
                }
                f2 = f7;
            }
            float f9 = f2;
            if (easing != null) {
                if (Float.isNaN(f6)) {
                    f6 = 1.0f;
                }
                float f10 = f6 - f4;
                d = (((float) easing.get((fMin - f4) / f10)) * f10) + f4;
            }
            this.mSpline[0].getPos(d, this.mInterpolateData);
            CurveFit curveFit = this.mArcSpline;
            if (curveFit != null) {
                double[] dArr = this.mInterpolateData;
                if (dArr.length > 0) {
                    curveFit.getPos(d, dArr);
                }
            }
            int i5 = i3 * 2;
            this.mStartMotionPath.getCenter(d, this.mInterpolateVariables, this.mInterpolateData, fArr, i5);
            if (keyCycleOscillator != null) {
                fArr[i5] = fArr[i5] + keyCycleOscillator.get(fMin);
            } else if (splineSet != null) {
                fArr[i5] = fArr[i5] + splineSet.get(fMin);
            }
            if (keyCycleOscillator2 != null) {
                int i6 = i5 + 1;
                fArr[i6] = fArr[i6] + keyCycleOscillator2.get(fMin);
            } else if (splineSet2 != null) {
                int i7 = i5 + 1;
                fArr[i7] = fArr[i7] + splineSet2.get(fMin);
            }
            i3++;
            i2 = i;
            f2 = f9;
            f = 1.0f;
        }
    }

    double[] getPos(double d) {
        this.mSpline[0].getPos(d, this.mInterpolateData);
        CurveFit curveFit = this.mArcSpline;
        if (curveFit != null) {
            double[] dArr = this.mInterpolateData;
            if (dArr.length > 0) {
                curveFit.getPos(d, dArr);
            }
        }
        return this.mInterpolateData;
    }

    private float getPreCycleDistance() {
        float[] fArr = new float[2];
        float f = 1.0f / 99;
        double d = 0.0d;
        double d2 = 0.0d;
        int i = 0;
        float fHypot = 0.0f;
        while (i < 100) {
            float f2 = i * f;
            double d3 = f2;
            Easing easing = this.mStartMotionPath.mKeyFrameEasing;
            ArrayList arrayList = this.mMotionPaths;
            int size = arrayList.size();
            float f3 = Float.NaN;
            int i2 = 0;
            float f4 = 0.0f;
            while (i2 < size) {
                Object obj = arrayList.get(i2);
                i2++;
                MotionPaths motionPaths = (MotionPaths) obj;
                float f5 = f;
                Easing easing2 = motionPaths.mKeyFrameEasing;
                if (easing2 != null) {
                    float f6 = motionPaths.mTime;
                    if (f6 < f2) {
                        f4 = f6;
                        easing = easing2;
                    } else if (Float.isNaN(f3)) {
                        f3 = motionPaths.mTime;
                    }
                }
                f = f5;
            }
            float f7 = f;
            if (easing != null) {
                if (Float.isNaN(f3)) {
                    f3 = 1.0f;
                }
                float f8 = f3 - f4;
                d3 = (((float) easing.get((f2 - f4) / f8)) * f8) + f4;
            }
            double d4 = d3;
            this.mSpline[0].getPos(d4, this.mInterpolateData);
            int i3 = i;
            this.mStartMotionPath.getCenter(d4, this.mInterpolateVariables, this.mInterpolateData, fArr, 0);
            if (i3 > 0) {
                fHypot += (float) Math.hypot(d2 - ((double) fArr[1]), d - ((double) fArr[0]));
            }
            d = fArr[0];
            d2 = fArr[1];
            i = i3 + 1;
            f = f7;
        }
        return fHypot;
    }

    public int buildKeyFrames(float[] fArr, int[] iArr, int[] iArr2) {
        if (fArr == null) {
            return 0;
        }
        double[] timePoints = this.mSpline[0].getTimePoints();
        if (iArr != null) {
            ArrayList arrayList = this.mMotionPaths;
            int size = arrayList.size();
            int i = 0;
            int i2 = 0;
            while (i2 < size) {
                Object obj = arrayList.get(i2);
                i2++;
                iArr[i] = ((MotionPaths) obj).mMode;
                i++;
            }
        }
        if (iArr2 != null) {
            ArrayList arrayList2 = this.mMotionPaths;
            int size2 = arrayList2.size();
            int i3 = 0;
            int i4 = 0;
            while (i4 < size2) {
                Object obj2 = arrayList2.get(i4);
                i4++;
                iArr2[i3] = (int) (((MotionPaths) obj2).mPosition * 100.0f);
                i3++;
            }
        }
        int i5 = 0;
        for (int i6 = 0; i6 < timePoints.length; i6++) {
            this.mSpline[0].getPos(timePoints[i6], this.mInterpolateData);
            this.mStartMotionPath.getCenter(timePoints[i6], this.mInterpolateVariables, this.mInterpolateData, fArr, i5);
            i5 += 2;
        }
        return i5 / 2;
    }

    public void buildRect(float f, float[] fArr, int i) {
        this.mSpline[0].getPos(getAdjustedPosition(f, null), this.mInterpolateData);
        this.mStartMotionPath.getRect(this.mInterpolateVariables, this.mInterpolateData, fArr, i);
    }

    private void insertKey(MotionPaths motionPaths) {
        ArrayList arrayList = this.mMotionPaths;
        int size = arrayList.size();
        MotionPaths motionPaths2 = null;
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            MotionPaths motionPaths3 = (MotionPaths) obj;
            if (motionPaths.mPosition == motionPaths3.mPosition) {
                motionPaths2 = motionPaths3;
            }
        }
        if (motionPaths2 != null) {
            this.mMotionPaths.remove(motionPaths2);
        }
        int iBinarySearch = Collections.binarySearch(this.mMotionPaths, motionPaths);
        if (iBinarySearch == 0) {
            Utils.loge("MotionController", " KeyPath position \"" + motionPaths.mPosition + "\" outside of range");
        }
        this.mMotionPaths.add((-iBinarySearch) - 1, motionPaths);
    }

    public void addKey(MotionKey motionKey) {
        this.mKeyList.add(motionKey);
    }

    public void setPathMotionArc(int i) {
        this.mPathMotionArc = i;
    }

    /* JADX WARN: Multi-variable type inference failed */
    public void setup(int i, int i2, float f, long j) {
        HashSet<String> hashSet;
        HashSet<String> hashSet2;
        int i3;
        String[] strArr;
        int i4;
        CustomVariable customVariable;
        SplineSet splineSetMakeSpline;
        CustomVariable customVariable2;
        Integer num;
        HashSet hashSet3;
        HashSet<String> hashSet4;
        SplineSet splineSetMakeSpline2;
        CustomVariable customVariable3;
        new HashSet();
        HashSet hashSet5 = new HashSet();
        HashSet<String> hashSet6 = new HashSet<>();
        HashSet<String> hashSet7 = new HashSet<>();
        HashMap<String, Integer> map = new HashMap<>();
        setupRelative();
        int i5 = this.mPathMotionArc;
        if (i5 != -1) {
            MotionPaths motionPaths = this.mStartMotionPath;
            if (motionPaths.mPathMotionArc == -1) {
                motionPaths.mPathMotionArc = i5;
            }
        }
        this.mStartPoint.different(this.mEndPoint, hashSet6);
        ArrayList arrayList = this.mKeyList;
        if (arrayList != null) {
            int size = arrayList.size();
            int i6 = 0;
            while (i6 < size) {
                Object obj = arrayList.get(i6);
                i6++;
                MotionKey motionKey = (MotionKey) obj;
                if (motionKey instanceof MotionKeyPosition) {
                    MotionKeyPosition motionKeyPosition = (MotionKeyPosition) motionKey;
                    insertKey(new MotionPaths(i, i2, motionKeyPosition, this.mStartMotionPath, this.mEndMotionPath));
                    int i7 = motionKeyPosition.mCurveFit;
                    if (i7 != -1) {
                        this.mCurveFitType = i7;
                    }
                } else if (motionKey instanceof MotionKeyCycle) {
                    motionKey.getAttributeNames(hashSet7);
                } else {
                    motionKey.setInterpolation(map);
                    motionKey.getAttributeNames(hashSet6);
                }
            }
        }
        int i8 = 1;
        if (hashSet6.isEmpty()) {
            hashSet = hashSet5;
            hashSet2 = hashSet7;
            i3 = 1;
        } else {
            this.mAttributesMap = new HashMap();
            for (String str : hashSet6) {
                if (str.startsWith("CUSTOM,")) {
                    KeyFrameArray.CustomVar customVar = new KeyFrameArray.CustomVar();
                    String str2 = str.split(StringUtils.COMMA)[i8];
                    ArrayList arrayList2 = this.mKeyList;
                    int size2 = arrayList2.size();
                    int i9 = 0;
                    while (i9 < size2) {
                        Object obj2 = arrayList2.get(i9);
                        i9++;
                        HashSet hashSet8 = hashSet5;
                        MotionKey motionKey2 = (MotionKey) obj2;
                        HashSet<String> hashSet9 = hashSet7;
                        HashMap map2 = motionKey2.mCustom;
                        if (map2 != null && (customVariable3 = (CustomVariable) map2.get(str2)) != null) {
                            customVar.append(motionKey2.mFramePosition, customVariable3);
                        }
                        hashSet7 = hashSet9;
                        hashSet5 = hashSet8;
                    }
                    hashSet3 = hashSet5;
                    hashSet4 = hashSet7;
                    splineSetMakeSpline2 = SplineSet.makeCustomSplineSet(str, customVar);
                } else {
                    hashSet3 = hashSet5;
                    hashSet4 = hashSet7;
                    splineSetMakeSpline2 = SplineSet.makeSpline(str, j);
                }
                if (splineSetMakeSpline2 != null) {
                    splineSetMakeSpline2.setType(str);
                    this.mAttributesMap.put(str, splineSetMakeSpline2);
                }
                i8 = i8;
                hashSet7 = hashSet4;
                hashSet5 = hashSet3;
            }
            hashSet = hashSet5;
            hashSet2 = hashSet7;
            i3 = i8;
            ArrayList arrayList3 = this.mKeyList;
            if (arrayList3 != null) {
                int size3 = arrayList3.size();
                int i10 = 0;
                while (i10 < size3) {
                    Object obj3 = arrayList3.get(i10);
                    i10++;
                    MotionKey motionKey3 = (MotionKey) obj3;
                    if (motionKey3 instanceof MotionKeyAttributes) {
                        motionKey3.addValues(this.mAttributesMap);
                    }
                }
            }
            this.mStartPoint.addValues(this.mAttributesMap, 0);
            this.mEndPoint.addValues(this.mAttributesMap, 100);
            for (String str3 : this.mAttributesMap.keySet()) {
                int iIntValue = (!map.containsKey(str3) || (num = map.get(str3)) == null) ? 0 : num.intValue();
                SplineSet splineSet = (SplineSet) this.mAttributesMap.get(str3);
                if (splineSet != null) {
                    splineSet.setup(iIntValue);
                }
            }
        }
        if (!hashSet.isEmpty()) {
            if (this.mTimeCycleAttributesMap == null) {
                this.mTimeCycleAttributesMap = new HashMap();
            }
            for (String str4 : hashSet) {
                if (!this.mTimeCycleAttributesMap.containsKey(str4)) {
                    if (str4.startsWith("CUSTOM,")) {
                        KeyFrameArray.CustomVar customVar2 = new KeyFrameArray.CustomVar();
                        String str5 = str4.split(StringUtils.COMMA)[i3];
                        ArrayList arrayList4 = this.mKeyList;
                        int size4 = arrayList4.size();
                        int i11 = 0;
                        while (i11 < size4) {
                            Object obj4 = arrayList4.get(i11);
                            i11++;
                            MotionKey motionKey4 = (MotionKey) obj4;
                            HashMap map3 = motionKey4.mCustom;
                            if (map3 != null && (customVariable2 = (CustomVariable) map3.get(str5)) != null) {
                                customVar2.append(motionKey4.mFramePosition, customVariable2);
                            }
                        }
                        splineSetMakeSpline = SplineSet.makeCustomSplineSet(str4, customVar2);
                    } else {
                        splineSetMakeSpline = SplineSet.makeSpline(str4, j);
                    }
                    if (splineSetMakeSpline != null) {
                        splineSetMakeSpline.setType(str4);
                    }
                }
            }
            ArrayList arrayList5 = this.mKeyList;
            if (arrayList5 != null) {
                int size5 = arrayList5.size();
                int i12 = 0;
                while (i12 < size5) {
                    Object obj5 = arrayList5.get(i12);
                    i12++;
                }
            }
            for (String str6 : this.mTimeCycleAttributesMap.keySet()) {
                ((TimeCycleSplineSet) this.mTimeCycleAttributesMap.get(str6)).setup(map.containsKey(str6) ? map.get(str6).intValue() : 0);
            }
        }
        int size6 = this.mMotionPaths.size();
        int i13 = size6 + 2;
        MotionPaths[] motionPathsArr = new MotionPaths[i13];
        motionPathsArr[0] = this.mStartMotionPath;
        motionPathsArr[size6 + 1] = this.mEndMotionPath;
        if (this.mMotionPaths.size() > 0 && this.mCurveFitType == MotionKey.UNSET) {
            this.mCurveFitType = 0;
        }
        ArrayList arrayList6 = this.mMotionPaths;
        int size7 = arrayList6.size();
        int i14 = i3;
        int i15 = 0;
        while (i15 < size7) {
            Object obj6 = arrayList6.get(i15);
            i15++;
            motionPathsArr[i14] = (MotionPaths) obj6;
            i14++;
        }
        HashSet hashSet10 = new HashSet();
        for (String str7 : this.mEndMotionPath.mCustomAttributes.keySet()) {
            if (this.mStartMotionPath.mCustomAttributes.containsKey(str7)) {
                if (!hashSet6.contains("CUSTOM," + str7)) {
                    hashSet10.add(str7);
                }
            }
        }
        String[] strArr2 = (String[]) hashSet10.toArray(new String[0]);
        this.mAttributeNames = strArr2;
        this.mAttributeInterpolatorCount = new int[strArr2.length];
        int i16 = 0;
        while (true) {
            strArr = this.mAttributeNames;
            if (i16 >= strArr.length) {
                break;
            }
            String str8 = strArr[i16];
            this.mAttributeInterpolatorCount[i16] = 0;
            for (int i17 = 0; i17 < i13; i17++) {
                if (motionPathsArr[i17].mCustomAttributes.containsKey(str8) && (customVariable = (CustomVariable) motionPathsArr[i17].mCustomAttributes.get(str8)) != null) {
                    int[] iArr = this.mAttributeInterpolatorCount;
                    iArr[i16] = iArr[i16] + customVariable.numberOfInterpolatedValues();
                    break;
                }
            }
            i16++;
        }
        boolean z = motionPathsArr[0].mPathMotionArc != -1 ? i3 : 0;
        int length = 18 + strArr.length;
        boolean[] zArr = new boolean[length];
        for (int i18 = i3; i18 < i13; i18++) {
            motionPathsArr[i18].different(motionPathsArr[i18 - 1], zArr, this.mAttributeNames, z);
        }
        int i19 = 0;
        for (int i20 = i3; i20 < length; i20++) {
            if (zArr[i20]) {
                i19++;
            }
        }
        this.mInterpolateVariables = new int[i19];
        int i21 = 2;
        int iMax = Math.max(2, i19);
        this.mInterpolateData = new double[iMax];
        this.mInterpolateVelocity = new double[iMax];
        int i22 = 0;
        for (int i23 = i3; i23 < length; i23++) {
            if (zArr[i23]) {
                this.mInterpolateVariables[i22] = i23;
                i22++;
            }
        }
        int[] iArr2 = new int[2];
        iArr2[i3] = this.mInterpolateVariables.length;
        iArr2[0] = i13;
        Class cls = Double.TYPE;
        double[][] dArr = (double[][]) Array.newInstance((Class<?>) cls, iArr2);
        double[] dArr2 = new double[i13];
        for (int i24 = 0; i24 < i13; i24++) {
            motionPathsArr[i24].fillStandard(dArr[i24], this.mInterpolateVariables);
            dArr2[i24] = motionPathsArr[i24].mTime;
        }
        int i25 = 0;
        while (true) {
            int[] iArr3 = this.mInterpolateVariables;
            if (i25 >= iArr3.length) {
                break;
            }
            if (iArr3[i25] < MotionPaths.sNames.length) {
                String str9 = MotionPaths.sNames[this.mInterpolateVariables[i25]] + " [";
                for (int i26 = 0; i26 < i13; i26++) {
                    str9 = str9 + dArr[i26][i25];
                }
            }
            i25++;
        }
        this.mSpline = new CurveFit[this.mAttributeNames.length + 1];
        int i27 = 0;
        while (true) {
            String[] strArr3 = this.mAttributeNames;
            if (i27 >= strArr3.length) {
                break;
            }
            String str10 = strArr3[i27];
            double[] dArr3 = null;
            double[][] dArr4 = null;
            int i28 = 0;
            int i29 = 0;
            while (i28 < i13) {
                if (motionPathsArr[i28].hasCustomData(str10)) {
                    if (dArr4 == null) {
                        dArr3 = new double[i13];
                        int[] iArr4 = new int[i21];
                        iArr4[i3] = motionPathsArr[i28].getCustomDataCount(str10);
                        i4 = 0;
                        iArr4[0] = i13;
                        dArr4 = (double[][]) Array.newInstance((Class<?>) cls, iArr4);
                    } else {
                        i4 = 0;
                    }
                    MotionPaths motionPaths2 = motionPathsArr[i28];
                    dArr3[i29] = motionPaths2.mTime;
                    motionPaths2.getCustomData(str10, dArr4[i29], i4);
                    i29++;
                }
                i28++;
                i27 = i27;
                i21 = 2;
            }
            int i30 = i27 + 1;
            this.mSpline[i30] = CurveFit.get(this.mCurveFitType, Arrays.copyOf(dArr3, i29), (double[][]) Arrays.copyOf(dArr4, i29));
            i27 = i30;
            i21 = 2;
        }
        int i31 = 0;
        this.mSpline[0] = CurveFit.get(this.mCurveFitType, dArr2, dArr);
        if (motionPathsArr[0].mPathMotionArc != -1) {
            int[] iArr5 = new int[i13];
            double[] dArr5 = new double[i13];
            int[] iArr6 = new int[2];
            iArr6[i3] = 2;
            iArr6[0] = i13;
            double[][] dArr6 = (double[][]) Array.newInstance((Class<?>) cls, iArr6);
            for (int i32 = 0; i32 < i13; i32++) {
                MotionPaths motionPaths3 = motionPathsArr[i32];
                iArr5[i32] = motionPaths3.mPathMotionArc;
                dArr5[i32] = motionPaths3.mTime;
                double[] dArr7 = dArr6[i32];
                dArr7[0] = motionPaths3.mX;
                dArr7[i3] = motionPaths3.mY;
            }
            i31 = 0;
            this.mArcSpline = CurveFit.getArc(iArr5, dArr5, dArr6);
        }
        this.mCycleMap = new HashMap();
        if (this.mKeyList != null) {
            float preCycleDistance = Float.NaN;
            for (String str11 : hashSet2) {
                KeyCycleOscillator keyCycleOscillatorMakeWidgetCycle = KeyCycleOscillator.makeWidgetCycle(str11);
                if (keyCycleOscillatorMakeWidgetCycle != null) {
                    if (keyCycleOscillatorMakeWidgetCycle.variesByPath() && Float.isNaN(preCycleDistance)) {
                        preCycleDistance = getPreCycleDistance();
                    }
                    keyCycleOscillatorMakeWidgetCycle.setType(str11);
                    this.mCycleMap.put(str11, keyCycleOscillatorMakeWidgetCycle);
                }
            }
            ArrayList arrayList7 = this.mKeyList;
            int size8 = arrayList7.size();
            int i33 = i31;
            while (i33 < size8) {
                Object obj7 = arrayList7.get(i33);
                i33++;
                MotionKey motionKey5 = (MotionKey) obj7;
                if (motionKey5 instanceof MotionKeyCycle) {
                    ((MotionKeyCycle) motionKey5).addCycleValues(this.mCycleMap);
                }
            }
            Iterator it = this.mCycleMap.values().iterator();
            while (it.hasNext()) {
                ((KeyCycleOscillator) it.next()).setup(preCycleDistance);
            }
        }
    }

    public String toString() {
        return " start: x: " + this.mStartMotionPath.mX + " y: " + this.mStartMotionPath.mY + " end: x: " + this.mEndMotionPath.mX + " y: " + this.mEndMotionPath.mY;
    }

    private void readView(MotionPaths motionPaths) {
        motionPaths.setBounds(this.mView.getX(), this.mView.getY(), this.mView.getWidth(), this.mView.getHeight());
    }

    public void setView(MotionWidget motionWidget) {
        this.mView = motionWidget;
    }

    public MotionWidget getView() {
        return this.mView;
    }

    public void setStart(MotionWidget motionWidget) {
        MotionPaths motionPaths = this.mStartMotionPath;
        motionPaths.mTime = 0.0f;
        motionPaths.mPosition = 0.0f;
        motionPaths.setBounds(motionWidget.getX(), motionWidget.getY(), motionWidget.getWidth(), motionWidget.getHeight());
        this.mStartMotionPath.applyParameters(motionWidget);
        this.mStartPoint.setState(motionWidget);
        TypedBundle motionProperties = motionWidget.getWidgetFrame().getMotionProperties();
        if (motionProperties != null) {
            motionProperties.applyDelta(this);
        }
    }

    public void setEnd(MotionWidget motionWidget) {
        MotionPaths motionPaths = this.mEndMotionPath;
        motionPaths.mTime = 1.0f;
        motionPaths.mPosition = 1.0f;
        readView(motionPaths);
        this.mEndMotionPath.setBounds(motionWidget.getLeft(), motionWidget.getTop(), motionWidget.getWidth(), motionWidget.getHeight());
        this.mEndMotionPath.applyParameters(motionWidget);
        this.mEndPoint.setState(motionWidget);
    }

    public void setStartState(ViewState viewState, MotionWidget motionWidget, int i, int i2, int i3) {
        MotionPaths motionPaths = this.mStartMotionPath;
        motionPaths.mTime = 0.0f;
        motionPaths.mPosition = 0.0f;
        Rect rect = new Rect();
        if (i == 1) {
            int i4 = viewState.left + viewState.right;
            rect.left = ((viewState.top + viewState.bottom) - viewState.width()) / 2;
            rect.top = i2 - ((i4 + viewState.height()) / 2);
            rect.right = rect.left + viewState.width();
            rect.bottom = rect.top + viewState.height();
        } else if (i == 2) {
            int i5 = viewState.left + viewState.right;
            rect.left = i3 - (((viewState.top + viewState.bottom) + viewState.width()) / 2);
            rect.top = (i5 - viewState.height()) / 2;
            rect.right = rect.left + viewState.width();
            rect.bottom = rect.top + viewState.height();
        }
        this.mStartMotionPath.setBounds(rect.left, rect.top, rect.width(), rect.height());
        this.mStartPoint.setState(rect, motionWidget, i, viewState.rotation);
    }

    private static DifferentialInterpolator getInterpolator(int i, String str, int i2) {
        if (i != -1) {
            return null;
        }
        final Easing interpolator = Easing.getInterpolator(str);
        return new DifferentialInterpolator() { // from class: androidx.constraintlayout.core.motion.Motion.1
            float mX;

            @Override // com.scanflow.datacapture.barinternal.androidx.constraintlayout.core.motion.utils.DifferentialInterpolator
            public float getInterpolation(float f) {
                this.mX = f;
                return (float) interpolator.get(f);
            }
        };
    }

    private float getAdjustedPosition(float f, float[] fArr) {
        float f2 = 0.0f;
        if (fArr != null) {
            fArr[0] = 1.0f;
        } else {
            float f3 = this.mStaggerScale;
            if (f3 != 1.0d) {
                float f4 = this.mStaggerOffset;
                if (f < f4) {
                    f = 0.0f;
                }
                if (f > f4 && f < 1.0d) {
                    f = Math.min((f - f4) * f3, 1.0f);
                }
            }
        }
        Easing easing = this.mStartMotionPath.mKeyFrameEasing;
        ArrayList arrayList = this.mMotionPaths;
        int size = arrayList.size();
        float f5 = Float.NaN;
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            MotionPaths motionPaths = (MotionPaths) obj;
            Easing easing2 = motionPaths.mKeyFrameEasing;
            if (easing2 != null) {
                float f6 = motionPaths.mTime;
                if (f6 < f) {
                    easing = easing2;
                    f2 = f6;
                } else if (Float.isNaN(f5)) {
                    f5 = motionPaths.mTime;
                }
            }
        }
        if (easing != null) {
            float f7 = (Float.isNaN(f5) ? 1.0f : f5) - f2;
            double d = (f - f2) / f7;
            f = (((float) easing.get(d)) * f7) + f2;
            if (fArr != null) {
                fArr[0] = (float) easing.getDiff(d);
            }
        }
        return f;
    }

    public boolean interpolate(MotionWidget motionWidget, float f, long j, KeyCache keyCache) {
        float interpolation;
        MotionWidget motionWidget2 = motionWidget;
        float adjustedPosition = getAdjustedPosition(f, null);
        int i = this.mQuantizeMotionSteps;
        if (i != -1) {
            float f2 = 1.0f / i;
            float fFloor = ((float) Math.floor(adjustedPosition / f2)) * f2;
            float f3 = (adjustedPosition % f2) / f2;
            if (!Float.isNaN(this.mQuantizeMotionPhase)) {
                f3 = (f3 + this.mQuantizeMotionPhase) % 1.0f;
            }
            DifferentialInterpolator differentialInterpolator = this.mQuantizeMotionInterpolator;
            if (differentialInterpolator != null) {
                interpolation = differentialInterpolator.getInterpolation(f3);
            } else {
                interpolation = ((double) f3) > 0.5d ? 1.0f : 0.0f;
            }
            adjustedPosition = (interpolation * f2) + fFloor;
        }
        float f4 = adjustedPosition;
        HashMap map = this.mAttributesMap;
        if (map != null) {
            Iterator it = map.values().iterator();
            while (it.hasNext()) {
                ((SplineSet) it.next()).setProperty(motionWidget2, f4);
            }
        }
        CurveFit[] curveFitArr = this.mSpline;
        if (curveFitArr != null) {
            double d = f4;
            curveFitArr[0].getPos(d, this.mInterpolateData);
            this.mSpline[0].getSlope(d, this.mInterpolateVelocity);
            CurveFit curveFit = this.mArcSpline;
            if (curveFit != null) {
                double[] dArr = this.mInterpolateData;
                if (dArr.length > 0) {
                    curveFit.getPos(d, dArr);
                    this.mArcSpline.getSlope(d, this.mInterpolateVelocity);
                }
            }
            if (!this.mNoMovement) {
                this.mStartMotionPath.setView(f4, motionWidget2, this.mInterpolateVariables, this.mInterpolateData, this.mInterpolateVelocity, null);
                f4 = f4;
                motionWidget2 = motionWidget2;
            }
            if (this.mTransformPivotTarget != -1) {
                if (this.mTransformPivotView == null) {
                    this.mTransformPivotView = motionWidget2.getParent().findViewById(this.mTransformPivotTarget);
                }
                MotionWidget motionWidget3 = this.mTransformPivotView;
                if (motionWidget3 != null) {
                    float top = (motionWidget3.getTop() + this.mTransformPivotView.getBottom()) / 2.0f;
                    float left = (this.mTransformPivotView.getLeft() + this.mTransformPivotView.getRight()) / 2.0f;
                    if (motionWidget2.getRight() - motionWidget2.getLeft() > 0 && motionWidget2.getBottom() - motionWidget2.getTop() > 0) {
                        float left2 = left - motionWidget2.getLeft();
                        float top2 = top - motionWidget2.getTop();
                        motionWidget2.setPivotX(left2);
                        motionWidget2.setPivotY(top2);
                    }
                }
            }
            int i2 = 1;
            while (true) {
                CurveFit[] curveFitArr2 = this.mSpline;
                if (i2 >= curveFitArr2.length) {
                    break;
                }
                curveFitArr2[i2].getPos(d, this.mValuesBuff);
                ((CustomVariable) this.mStartMotionPath.mCustomAttributes.get(this.mAttributeNames[i2 - 1])).setInterpolatedValue(motionWidget2, this.mValuesBuff);
                i2++;
            }
            MotionConstrainedPoint motionConstrainedPoint = this.mStartPoint;
            if (motionConstrainedPoint.mVisibilityMode == 0) {
                if (f4 <= 0.0f) {
                    motionWidget2.setVisibility(motionConstrainedPoint.mVisibility);
                } else if (f4 >= 1.0f) {
                    motionWidget2.setVisibility(this.mEndPoint.mVisibility);
                } else if (this.mEndPoint.mVisibility != motionConstrainedPoint.mVisibility) {
                    motionWidget2.setVisibility(4);
                }
            }
            MotionKeyTrigger[] motionKeyTriggerArr = this.mKeyTriggers;
            if (motionKeyTriggerArr != null && motionKeyTriggerArr.length > 0) {
                MotionKeyTrigger motionKeyTrigger = motionKeyTriggerArr[0];
                throw null;
            }
        } else {
            MotionPaths motionPaths = this.mStartMotionPath;
            float f5 = motionPaths.mX;
            MotionPaths motionPaths2 = this.mEndMotionPath;
            float f6 = f5 + ((motionPaths2.mX - f5) * f4);
            float f7 = motionPaths.mY;
            float f8 = f7 + ((motionPaths2.mY - f7) * f4);
            float f9 = motionPaths.mWidth;
            float f10 = f9 + ((motionPaths2.mWidth - f9) * f4);
            float f11 = motionPaths.mHeight;
            float f12 = f6 + 0.5f;
            float f13 = f8 + 0.5f;
            motionWidget2.layout((int) f12, (int) f13, (int) (f12 + f10), (int) (f13 + f11 + ((motionPaths2.mHeight - f11) * f4)));
        }
        HashMap map2 = this.mCycleMap;
        if (map2 != null) {
            for (KeyCycleOscillator keyCycleOscillator : map2.values()) {
                if (keyCycleOscillator instanceof KeyCycleOscillator.PathRotateSet) {
                    double[] dArr2 = this.mInterpolateVelocity;
                    ((KeyCycleOscillator.PathRotateSet) keyCycleOscillator).setPathRotate(motionWidget2, f4, dArr2[0], dArr2[1]);
                } else {
                    keyCycleOscillator.setProperty(motionWidget2, f4);
                }
            }
        }
        return false;
    }

    public void getDpDt(float f, float f2, float f3, float[] fArr) {
        double[] dArr;
        float adjustedPosition = getAdjustedPosition(f, this.mVelocity);
        CurveFit[] curveFitArr = this.mSpline;
        int i = 0;
        if (curveFitArr != null) {
            double d = adjustedPosition;
            curveFitArr[0].getSlope(d, this.mInterpolateVelocity);
            this.mSpline[0].getPos(d, this.mInterpolateData);
            float f4 = this.mVelocity[0];
            while (true) {
                dArr = this.mInterpolateVelocity;
                if (i >= dArr.length) {
                    break;
                }
                dArr[i] = dArr[i] * ((double) f4);
                i++;
            }
            CurveFit curveFit = this.mArcSpline;
            if (curveFit != null) {
                double[] dArr2 = this.mInterpolateData;
                if (dArr2.length > 0) {
                    curveFit.getPos(d, dArr2);
                    this.mArcSpline.getSlope(d, this.mInterpolateVelocity);
                    this.mStartMotionPath.setDpDt(f2, f3, fArr, this.mInterpolateVariables, this.mInterpolateVelocity, this.mInterpolateData);
                    return;
                }
                return;
            }
            this.mStartMotionPath.setDpDt(f2, f3, fArr, this.mInterpolateVariables, dArr, this.mInterpolateData);
            return;
        }
        MotionPaths motionPaths = this.mEndMotionPath;
        float f5 = motionPaths.mX;
        MotionPaths motionPaths2 = this.mStartMotionPath;
        float f6 = f5 - motionPaths2.mX;
        float f7 = motionPaths.mY - motionPaths2.mY;
        float f8 = (motionPaths.mWidth - motionPaths2.mWidth) + f6;
        float f9 = (motionPaths.mHeight - motionPaths2.mHeight) + f7;
        fArr[0] = (f6 * (1.0f - f2)) + (f8 * f2);
        fArr[1] = (f7 * (1.0f - f3)) + (f9 * f3);
    }

    public int getDrawPath() {
        int iMax = this.mStartMotionPath.mDrawPath;
        ArrayList arrayList = this.mMotionPaths;
        int size = arrayList.size();
        int i = 0;
        while (i < size) {
            Object obj = arrayList.get(i);
            i++;
            iMax = Math.max(iMax, ((MotionPaths) obj).mDrawPath);
        }
        return Math.max(iMax, this.mEndMotionPath.mDrawPath);
    }

    public void setDrawPath(int i) {
        this.mStartMotionPath.mDrawPath = i;
    }

    public int getKeyFramePositions(int[] iArr, float[] fArr) {
        ArrayList arrayList = this.mKeyList;
        int size = arrayList.size();
        int i = 0;
        int i2 = 0;
        int i3 = 0;
        while (i2 < size) {
            int i4 = i2 + 1;
            MotionKey motionKey = (MotionKey) arrayList.get(i2);
            int i5 = motionKey.mFramePosition;
            iArr[i] = (motionKey.mType * 1000) + i5;
            double d = i5 / 100.0f;
            this.mSpline[0].getPos(d, this.mInterpolateData);
            this.mStartMotionPath.getCenter(d, this.mInterpolateVariables, this.mInterpolateData, fArr, i3);
            i3 += 2;
            i2 = i4;
            i++;
        }
        return i;
    }

    public int getKeyFrameInfo(int i, int[] iArr) {
        float[] fArr = new float[2];
        ArrayList arrayList = this.mKeyList;
        int size = arrayList.size();
        int i2 = 0;
        int i3 = 0;
        int i4 = 0;
        while (i2 < size) {
            int i5 = i2 + 1;
            MotionKey motionKey = (MotionKey) arrayList.get(i2);
            int i6 = motionKey.mType;
            if (i6 == i || i != -1) {
                iArr[i4] = 0;
                iArr[i4 + 1] = i6;
                int i7 = motionKey.mFramePosition;
                iArr[i4 + 2] = i7;
                double d = i7 / 100.0f;
                this.mSpline[0].getPos(d, this.mInterpolateData);
                this.mStartMotionPath.getCenter(d, this.mInterpolateVariables, this.mInterpolateData, fArr, 0);
                iArr[i4 + 3] = Float.floatToIntBits(fArr[0]);
                int i8 = i4 + 4;
                iArr[i8] = Float.floatToIntBits(fArr[1]);
                if (motionKey instanceof MotionKeyPosition) {
                    MotionKeyPosition motionKeyPosition = (MotionKeyPosition) motionKey;
                    iArr[i4 + 5] = motionKeyPosition.mPositionType;
                    iArr[i4 + 6] = Float.floatToIntBits(motionKeyPosition.mPercentX);
                    i8 = i4 + 7;
                    iArr[i8] = Float.floatToIntBits(motionKeyPosition.mPercentY);
                }
                int i9 = i8 + 1;
                iArr[i4] = i9 - i4;
                i3++;
                i4 = i9;
            }
            i2 = i5;
        }
        return i3;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, int i2) {
        if (i == 509) {
            setPathMotionArc(i2);
            return true;
        }
        if (i != 610) {
            return i == 704;
        }
        this.mQuantizeMotionSteps = i2;
        return true;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, float f) {
        if (602 == i) {
            this.mQuantizeMotionPhase = f;
            return true;
        }
        if (600 != i) {
            return false;
        }
        this.mMotionStagger = f;
        return true;
    }

    @Override // androidx.constraintlayout.core.motion.utils.TypedValues
    public boolean setValue(int i, String str) {
        if (705 == i || 611 == i) {
            this.mQuantizeMotionInterpolator = getInterpolator(-1, str, 0);
            return true;
        }
        if (605 != i) {
            return false;
        }
        this.mStartMotionPath.mAnimateRelativeTo = str;
        return true;
    }

    public void setStaggerScale(float f) {
        this.mStaggerScale = f;
    }

    public void setStaggerOffset(float f) {
        this.mStaggerOffset = f;
    }

    public float getMotionStagger() {
        return this.mMotionStagger;
    }

    public void setIdString(String str) {
        this.mId = str;
        this.mStartMotionPath.mId = str;
    }
}
