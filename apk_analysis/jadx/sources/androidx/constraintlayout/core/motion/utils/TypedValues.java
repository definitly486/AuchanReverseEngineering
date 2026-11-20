package androidx.constraintlayout.core.motion.utils;

import androidx.core.app.NotificationCompat;
import com.google.mlkit.common.MlKitException;
import okhttp3.internal.http.StatusLine;

/* JADX INFO: loaded from: classes.dex */
public interface TypedValues {
    public static final int BOOLEAN_MASK = 1;
    public static final int FLOAT_MASK = 4;
    public static final int INT_MASK = 2;
    public static final int STRING_MASK = 8;
    public static final String S_CUSTOM = "CUSTOM";
    public static final int TYPE_FRAME_POSITION = 100;
    public static final int TYPE_TARGET = 101;

    int getId(String str);

    boolean setValue(int i, float f);

    boolean setValue(int i, int i2);

    boolean setValue(int i, String str);

    boolean setValue(int i, boolean z);

    public interface AttributesType {
        public static final String[] KEY_WORDS = {"curveFit", "visibility", "alpha", "translationX", "translationY", "translationZ", "elevation", "rotationX", "rotationY", "rotationZ", "scaleX", "scaleY", "pivotX", "pivotY", NotificationCompat.CATEGORY_PROGRESS, "pathRotate", "easing", TypedValues.S_CUSTOM, "frame", "target", "pivotTarget"};

        static int getId(String str) {
            str.getClass();
            switch (str) {
                case "easing":
                    return 317;
                case "rotationX":
                    return StatusLine.HTTP_PERM_REDIRECT;
                case "rotationY":
                    return 309;
                case "rotationZ":
                    return 310;
                case "translationX":
                    return 304;
                case "translationY":
                    return 305;
                case "translationZ":
                    return 306;
                case "progress":
                    return 315;
                case "pivotX":
                    return 313;
                case "pivotY":
                    return 314;
                case "scaleX":
                    return 311;
                case "scaleY":
                    return 312;
                case "target":
                    return 101;
                case "elevation":
                    return StatusLine.HTTP_TEMP_REDIRECT;
                case "alpha":
                    return 303;
                case "frame":
                    return 100;
                case "curveFit":
                    return MlKitException.LOW_LIGHT_IMAGE_CAPTURE_PROCESSING_FAILURE;
                case "pathRotate":
                    return 316;
                case "pivotTarget":
                    return 318;
                case "visibility":
                    return 302;
                default:
                    return -1;
            }
        }
    }

    public interface CycleType {
        public static final String[] KEY_WORDS = {"curveFit", "visibility", "alpha", "translationX", "translationY", "translationZ", "elevation", "rotationX", "rotationY", "rotationZ", "scaleX", "scaleY", "pivotX", "pivotY", NotificationCompat.CATEGORY_PROGRESS, "pathRotate", "easing", "waveShape", "customWave", "period", "offset", "phase"};

        static int getId(String str) {
            str.getClass();
            switch (str) {
                case "easing":
                    return 420;
                case "rotationX":
                    return StatusLine.HTTP_PERM_REDIRECT;
                case "rotationY":
                    return 309;
                case "rotationZ":
                    return 310;
                case "translationX":
                    return 304;
                case "translationY":
                    return 305;
                case "translationZ":
                    return 306;
                case "progress":
                    return 315;
                case "pivotX":
                    return 313;
                case "pivotY":
                    return 314;
                case "scaleX":
                    return 311;
                case "scaleY":
                    return 312;
                case "alpha":
                    return 403;
                case "curveFit":
                    return 401;
                case "pathRotate":
                    return 416;
                case "visibility":
                    return 402;
                default:
                    return -1;
            }
        }
    }

    public interface PositionType {
        public static final String[] KEY_WORDS = {"transitionEasing", "drawPath", "percentWidth", "percentHeight", "sizePercent", "percentX", "percentY"};

        static int getId(String str) {
            str.getClass();
            switch (str) {
                case "transitionEasing":
                    return 501;
                case "percentWidth":
                    return 503;
                case "percentHeight":
                    return 504;
                case "drawPath":
                    return 502;
                case "sizePercent":
                    return 505;
                case "percentX":
                    return 506;
                case "percentY":
                    return 507;
                default:
                    return -1;
            }
        }
    }

    public interface MotionType {
        public static final String[] KEY_WORDS = {"Stagger", "PathRotate", "QuantizeMotionPhase", "TransitionEasing", "QuantizeInterpolator", "AnimateRelativeTo", "AnimateCircleAngleTo", "PathMotionArc", "DrawPath", "PolarRelativeTo", "QuantizeMotionSteps", "QuantizeInterpolatorType", "QuantizeInterpolatorID"};

        static int getId(String str) {
            str.getClass();
            switch (str) {
                case "AnimateCircleAngleTo":
                    return 606;
                case "QuantizeMotionPhase":
                    return 602;
                case "QuantizeMotionSteps":
                    return 610;
                case "PathRotate":
                    return 601;
                case "QuantizeInterpolator":
                    return 604;
                case "DrawPath":
                    return 608;
                case "Stagger":
                    return 600;
                case "PolarRelativeTo":
                    return 609;
                case "QuantizeInterpolatorType":
                    return 611;
                case "QuantizeInterpolatorID":
                    return 612;
                case "TransitionEasing":
                    return 603;
                case "AnimateRelativeTo":
                    return 605;
                case "PathMotionArc":
                    return 607;
                default:
                    return -1;
            }
        }
    }
}
