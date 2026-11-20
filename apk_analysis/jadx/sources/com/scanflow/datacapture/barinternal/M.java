package com.scanflow.datacapture.barinternal;

import android.app.Activity;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.PointF;
import android.graphics.PorterDuff;
import android.graphics.Rect;
import android.graphics.RectF;
import android.net.Uri;
import android.os.Handler;
import android.os.Looper;
import android.util.Log;
import android.util.Size;
import android.view.SurfaceView;
import androidx.camera.core.Camera;
import androidx.camera.core.CameraControl;
import androidx.camera.core.CameraInfo;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.ZoomState;
import androidx.core.view.ViewCompat;
import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleOwner;
import androidx.lifecycle.LifecycleRegistry;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.Observer;
import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.OnFailureListener;
import com.google.android.gms.tasks.OnSuccessListener;
import com.google.android.gms.tasks.Task;
import com.google.gson.Gson;
import com.google.mlkit.vision.barcode.BarcodeScanner;
import com.google.mlkit.vision.barcode.common.Barcode;
import com.google.mlkit.vision.common.InputImage;
import com.google.mlkit.vision.text.Text;
import com.google.mlkit.vision.text.TextRecognition;
import com.google.mlkit.vision.text.TextRecognizer;
import com.google.mlkit.vision.text.latin.TextRecognizerOptions;
import com.google.zxing.BinaryBitmap;
import com.google.zxing.DecodeHintType;
import com.google.zxing.LuminanceSource;
import com.google.zxing.MultiFormatReader;
import com.google.zxing.RGBLuminanceSource;
import com.google.zxing.common.GlobalHistogramBinarizer;
import com.google.zxing.common.HybridBinarizer;
import com.scanflow.datacapture.barcode.R;
import com.scanflow.datacapture.barcode.config.DecodeConfig;
import com.scanflow.datacapture.barinternal.boofcv.abst.fiducial.QrCodePreciseDetector;
import com.scanflow.datacapture.barinternal.boofcv.alg.fiducial.qrcode.QrCode;
import com.scanflow.datacapture.barinternal.boofcv.android.ConvertBitmap;
import com.scanflow.datacapture.barinternal.boofcv.factory.fiducial.ConfigQrCode;
import com.scanflow.datacapture.barinternal.boofcv.factory.fiducial.FactoryFiducial;
import com.scanflow.datacapture.barinternal.boofcv.struct.image.GrayU8;
import com.scanflow.datacapture.barinternal.georegression.struct.shapes.Polygon2D_F64;
import com.scanflow.datacapture.barinternal.kotlin.NoWhenBranchMatchedException;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__BuildersKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.GlobalScope;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.core.source.super_resolution.Device;
import com.scanflow.datacapture.core.source.super_resolution.Enhancement;
import com.scanflow.datacapture.core.source.super_resolution.EnhancementResult;
import com.scanflow.datacapture.core.source.super_resolution.ProcessResult;
import com.scanflow.datacapture.model.LowLightResponse;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import com.scanflow.datacapture.model.subscription.Result;
import com.scanflow.datacapture.model.subscription.SubscriptionResponse;
import com.scanflow.datacapture.sfbarcode.SFCameraView;
import com.scanflow.datacapture.sfcamera.SFTextOverlay;
import com.scanflow.datacapture.utils.BarcodeFormat;
import com.scanflow.datacapture.utils.ErrorMessageUtils;
import com.scanflow.datacapture.utils.ScanflowLog;
import com.scanflow.datacapture.utils.StorageUtils;
import com.scanflow.ui.ar.ArObject;
import com.scanflow.ui.ar.ArObjectTracker;
import com.scanflow.ui.ar.ArOverlayView;
import com.scanflow.ui.ar.BoundingBoxArOverlay;
import java.io.File;
import java.io.IOException;
import java.nio.charset.Charset;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Base64;
import java.util.Collections;
import java.util.Date;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.Locale;
import java.util.TimeZone;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.atomic.AtomicBoolean;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.GCMParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.Ref$FloatRef;
import kotlin.jvm.internal.StringCompanionObject;
import org.opencv.android.Utils;
import org.opencv.core.Mat;
import org.opencv.imgproc.Imgproc;

/* JADX INFO: loaded from: classes3.dex */
public final class M implements Analyzer, LifecycleOwner {
    public final String A;
    public final LinkedList B;
    public final MutableLiveData C;
    public final MutableLiveData D;
    public final Handler E;
    public ArrayList F;
    public final ArObjectTracker G;
    public final long H;
    public final long I;
    public final HashSet J;
    public final BeepManager K;
    public final v L;
    public BeepManager M;
    public Size N;
    public final SFCameraView O;
    public ScanflowReader.OnBarcodeScanResultCallback P;
    public ArrayList Q;
    public boolean R;
    public final AtomicBoolean S;
    public final SharedPreferences T;
    public final String U;
    public final String V;
    public final String W;
    public SubscriptionResponse X;
    public final int Y;
    public final int Z;
    public String a;
    public final MutableLiveData a0;
    public boolean b;
    public HashSet b0;
    public boolean c;
    public boolean d;
    public final C0089g e;
    public final Activity f;
    public final N g;
    public boolean h;
    public final ExecutorService i;
    public Matrix j;
    public Matrix k;
    public Matrix l;
    public final L m;
    public boolean n;
    public final float o;
    public boolean p;
    public boolean q;
    public final String r;
    public int s;
    public int t;
    public boolean u;
    public ScanflowReader.CameraUserConfig v;
    public final LifecycleRegistry w;
    public ArrayList x;
    public final int y;
    public final Enhancement z;

    public M(Activity mActivity, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, DecodeConfig decodeConfig) throws NoSuchPaddingException, NoSuchAlgorithmException, IOException, InvalidKeyException, InvalidAlgorithmParameterException {
        SharedPreferences sharedPreferences;
        MutableLiveData mutableLiveData;
        Pair pair;
        Intrinsics.checkNotNullParameter(mActivity, "mActivity");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        this.a = "qr_code";
        this.i = Executors.newSingleThreadExecutor();
        this.l = new Matrix();
        this.m = new L(CoroutineExceptionHandler.Key);
        this.o = 0.1f;
        this.p = true;
        this.r = "sharp";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.w = lifecycleRegistry;
        this.x = new ArrayList();
        this.y = 3;
        this.A = "SuperResolution";
        this.B = new LinkedList();
        MutableLiveData mutableLiveData2 = new MutableLiveData();
        this.C = mutableLiveData2;
        this.D = mutableLiveData2;
        this.E = new Handler(Looper.getMainLooper());
        this.F = new ArrayList();
        this.G = new ArObjectTracker();
        this.H = System.currentTimeMillis();
        System.currentTimeMillis();
        this.I = 2000L;
        this.J = new HashSet();
        this.N = new Size(1080, 1920);
        this.Q = new ArrayList();
        this.S = new AtomicBoolean(false);
        this.U = "SECRET_KEY_PREF_NAME";
        this.V = "SALTVALUE_PREF_NAME";
        this.W = "MODEL_FILE_KEY_PREF_NAME";
        this.Y = 20;
        this.Z = 55;
        MutableLiveData mutableLiveData3 = new MutableLiveData();
        mutableLiveData3.setValue(new Pair(55, 20));
        this.a0 = mutableLiveData3;
        Color.parseColor("#2256DE");
        Color.parseColor("#FF543E");
        Color.parseColor("#FFAF4D");
        Color.parseColor("#3098F1");
        this.b0 = new HashSet();
        new ArrayList();
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        this.O = sfCameraView;
        this.f = mActivity;
        ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
        scanflowLog.enable(false);
        BeepManager beepManager = new BeepManager(mActivity, Integer.valueOf(R.raw.oneofmany_beep));
        this.K = beepManager;
        beepManager.setVibrate(false);
        beepManager.setPlayBeep(true);
        MasterKey masterKeyBuild = new MasterKey.Builder(mActivity, "_androidx_security_master_key_").setKeyScheme(MasterKey.KeyScheme.AES256_GCM).build();
        N n = null;
        SharedPreferences sharedPreferences2 = null;
        if (masterKeyBuild == null) {
            Intrinsics.throwUninitializedPropertyAccessException("masterKey");
            masterKeyBuild = null;
        }
        SharedPreferences sharedPreferencesCreate = EncryptedSharedPreferences.create(mActivity, SCANFLOW_LICENSE_KEY, masterKeyBuild, EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV, EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM);
        this.T = sharedPreferencesCreate;
        if (sharedPreferencesCreate == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences = null;
        } else {
            sharedPreferences = sharedPreferencesCreate;
        }
        SharedPreferences.Editor editorEdit = sharedPreferences.edit();
        editorEdit.putString("MODEL_FILE_KEY_PREF_NAME", "WN*J8yH19c9szb9#");
        editorEdit.apply();
        if (sharedPreferencesCreate == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferencesCreate = null;
        }
        scanflowLog.v("MODEL_FILE", String.valueOf(sharedPreferencesCreate.getString("MODEL_FILE_KEY_PREF_NAME", "")));
        this.L = new v(mActivity);
        a(decodeConfig);
        try {
            this.e = new C0089g(mActivity);
            Log.v("SFBarcode", "Blur Detection Classifier initialized successfully");
        } catch (Exception e) {
            Log.e("SFBarcode", "Failed to initialize Blur Detection Classifier: " + e.getMessage());
            this.e = null;
        }
        if (mActivity.getAssets() != null) {
            SharedPreferences sharedPreferences3 = this.T;
            if (sharedPreferences3 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            } else {
                sharedPreferences2 = sharedPreferences3;
            }
            File fileA = AbstractC0095m.a(mActivity, String.valueOf(sharedPreferences2.getString(this.W, "")));
            Intrinsics.checkNotNull(fileA);
            n = new N(mActivity, fileA);
        }
        this.g = n;
        if (n != null) {
            n.a();
        }
        if (this.z == null) {
            Enhancement enhancement = new Enhancement(true);
            this.z = enhancement;
            enhancement.init(mActivity, this.A, Device.CPU, 4);
        }
        this.w.setCurrentState(Lifecycle.State.STARTED);
        ArOverlayView arOverlayView = sfCameraView.getArOverlayView();
        Intrinsics.checkNotNullExpressionValue(arOverlayView, "getArOverlayView(...)");
        a(arOverlayView);
        boolean zBooleanValue = sfCameraView.isBorderCornersRounded().booleanValue();
        int iIntValue = sfCameraView.mTopLeftColor().intValue();
        int iIntValue2 = sfCameraView.mTopRightColor().intValue();
        int iIntValue3 = sfCameraView.mBottomLeftColor().intValue();
        int iIntValue4 = sfCameraView.mBottomRightColor().intValue();
        if (decodeConfig != DecodeConfig.DOTMATRIX_WHITE && decodeConfig != DecodeConfig.DOTMATRIX_METAL) {
            if (decodeConfig == DecodeConfig.BARCODE) {
                this.Y = 10;
                this.Z = 80;
                mutableLiveData = new MutableLiveData();
                pair = new Pair(80, 10);
            } else {
                this.Y = 20;
                this.Z = 55;
                MutableLiveData mutableLiveData4 = new MutableLiveData();
                mutableLiveData4.setValue(new Pair(55, 20));
                this.a0 = mutableLiveData4;
            }
            SFTextOverlay sFTextOverlay = SFTextOverlay.INSTANCE;
            SurfaceView surfaceView = sfCameraView.getSurfaceView();
            Intrinsics.checkNotNullExpressionValue(surfaceView, "getSurfaceView(...)");
            sFTextOverlay.setTextCaptureOverlay(surfaceView, this.Z, this.Y, iIntValue, iIntValue2, iIntValue3, iIntValue4, zBooleanValue);
        }
        this.Y = 70;
        this.Z = 82;
        mutableLiveData = new MutableLiveData();
        pair = new Pair(82, 70);
        mutableLiveData.setValue(pair);
        this.a0 = mutableLiveData;
        SFTextOverlay sFTextOverlay2 = SFTextOverlay.INSTANCE;
        SurfaceView surfaceView2 = sfCameraView.getSurfaceView();
        Intrinsics.checkNotNullExpressionValue(surfaceView2, "getSurfaceView(...)");
        sFTextOverlay2.setTextCaptureOverlay(surfaceView2, this.Z, this.Y, iIntValue, iIntValue2, iIntValue3, iIntValue4, zBooleanValue);
    }

    public static final void a(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        SFCameraView sFCameraView = this$0.O;
        if (sFCameraView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sfCameraView");
            sFCameraView = null;
        }
        sFCameraView.setExpiredVisibility(Boolean.TRUE, ErrorMessageUtils.Error_13);
    }

    public static final void b(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        SFCameraView sFCameraView = this$0.O;
        if (sFCameraView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sfCameraView");
            sFCameraView = null;
        }
        sFCameraView.setExpiredVisibility(Boolean.FALSE, "Valid License");
    }

    public static final void c(M this_run) {
        Intrinsics.checkNotNullParameter(this_run, "$this_run");
        SFCameraView sFCameraView = this_run.O;
        if (sFCameraView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sfCameraView");
            sFCameraView = null;
        }
        Boolean bool = Boolean.TRUE;
        SubscriptionResponse subscriptionResponse = this_run.X;
        String message = subscriptionResponse != null ? subscriptionResponse.getMessage() : null;
        Intrinsics.checkNotNull(message);
        sFCameraView.setExpiredVisibility(bool, message);
    }

    public static final void d(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        SFCameraView sFCameraView = this$0.O;
        if (sFCameraView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sfCameraView");
            sFCameraView = null;
        }
        sFCameraView.setExpiredVisibility(Boolean.TRUE, ErrorMessageUtils.Error_19);
    }

    public static final void e(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.G.processObject(this$0.F);
    }

    public static final void f(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.G.processObject(this$0.F);
    }

    public static final void g(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.G.processObject(this$0.F);
    }

    public static final void h(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.G.processObject(this$0.F);
    }

    public static final void i(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.G.processObject((ArObject) null);
        ArrayList<ArObject> arrayList = new ArrayList<>();
        this$0.F = arrayList;
        this$0.G.processObject(arrayList);
    }

    public static final void j(M this$0) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        this$0.getClass();
    }

    /* JADX WARN: Code duplicated, block: B:173:0x042a  */
    /* JADX WARN: Code duplicated, block: B:228:0x0531 A[Catch: Exception -> 0x07d0, TryCatch #0 {Exception -> 0x07d0, blocks: (B:283:0x0646, B:225:0x052b, B:226:0x052d, B:228:0x0531, B:247:0x05b5, B:224:0x0528, B:229:0x0538, B:232:0x0542, B:234:0x0548, B:236:0x054c, B:237:0x0552, B:238:0x0560, B:240:0x0566, B:242:0x0591, B:243:0x059e, B:245:0x05a6, B:246:0x05b2, B:248:0x05ba, B:250:0x05c1, B:251:0x05c8, B:253:0x05ce, B:258:0x05e5, B:260:0x05e9, B:261:0x05ef, B:282:0x0644, B:262:0x05f3, B:264:0x05fa, B:265:0x05ff, B:266:0x0603, B:267:0x060a, B:269:0x0610, B:274:0x0627, B:276:0x062b, B:277:0x0631, B:278:0x0635, B:280:0x063c, B:281:0x0641, B:287:0x064b, B:288:0x064c, B:290:0x066f, B:291:0x0699, B:295:0x06c2, B:297:0x06e5, B:299:0x070e, B:300:0x0713, B:305:0x072b, B:307:0x075f, B:309:0x0767, B:311:0x0770, B:310:0x076c, B:296:0x06d4, B:118:0x02df), top: B:314:0x02af, inners: #1 }] */
    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer
    public final void analyze(ImageProxy imageProxy, Camera mCamera, ScanflowReader.CameraUserConfig cameraUserConfig, Analyzer.OnAnalyzeListener onAnalyzeListener, Object obj) {
        BeepManager beepManager;
        C0084b c0084b;
        C0084b c0084b2;
        LiveData<ZoomState> zoomState;
        ZoomState value;
        LiveData<ZoomState> zoomState2;
        ZoomState value2;
        LiveData<ZoomState> zoomState3;
        ZoomState value3;
        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback;
        CameraControl cameraControl;
        LiveData<ZoomState> zoomState4;
        ZoomState value4;
        LiveData<ZoomState> zoomState5;
        ZoomState value5;
        LiveData<ZoomState> zoomState6;
        ZoomState value6;
        C0086d c0086d;
        Resources resources;
        Configuration configuration;
        final M m = this;
        final Analyzer.OnAnalyzeListener listener = onAnalyzeListener;
        Intrinsics.checkNotNullParameter(imageProxy, "imageProxy");
        Intrinsics.checkNotNullParameter(mCamera, "mCamera");
        Intrinsics.checkNotNullParameter(cameraUserConfig, "cameraUserConfig");
        Intrinsics.checkNotNullParameter(listener, "listener");
        try {
            if (m.v == null) {
                m.v = cameraUserConfig;
            }
            if (m.M == null && cameraUserConfig.getBeepSoundResource() != null) {
                Activity activity = m.f;
                Intrinsics.checkNotNull(activity);
                BeepManager beepManager2 = new BeepManager(activity, cameraUserConfig.getBeepSoundResource());
                m.M = beepManager2;
                beepManager2.setVibrate(cameraUserConfig.getVibrate());
                Unit unit = Unit.INSTANCE;
                beepManager = m.M;
                if (beepManager != null) {
                    beepManager.setPlayBeep(cameraUserConfig.getPlayBeep());
                }
            } else if (m.M == null) {
                Activity activity2 = m.f;
                Intrinsics.checkNotNull(activity2);
                BeepManager beepManager3 = new BeepManager(activity2, Integer.valueOf(R.raw.beep));
                m.M = beepManager3;
                beepManager3.setVibrate(cameraUserConfig.getVibrate());
                Unit unit2 = Unit.INSTANCE;
                beepManager = m.M;
                if (beepManager != null) {
                    beepManager.setPlayBeep(cameraUserConfig.getPlayBeep());
                }
            }
            m.p = cameraUserConfig.isContinuousScan();
            m.q = cameraUserConfig.isPerformCaptureScan();
            m.R = cameraUserConfig.isNetworkAvailable();
            if (!m.S.get()) {
                String licenseInfo = cameraUserConfig.getLicenseInfo();
                if (licenseInfo.length() == 0 && !m.R) {
                    Activity activity3 = m.f;
                    if (activity3 != null) {
                        activity3.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda0
                            @Override // java.lang.Runnable
                            public final void run() {
                                M.d(this.f$0);
                            }
                        });
                        Unit unit3 = Unit.INSTANCE;
                    }
                    listener.onLicenseFailed(ErrorMessageUtils.Error_19);
                    return;
                }
                if (licenseInfo.length() == 0 && m.R) {
                    listener.onLicenseFailed("InProgress");
                    return;
                }
                SubscriptionResponse subscriptionResponse = (SubscriptionResponse) new Gson().fromJson(m.a(licenseInfo), SubscriptionResponse.class);
                m.X = subscriptionResponse;
                if (subscriptionResponse == null || subscriptionResponse.getResult() == null) {
                    Activity activity4 = m.f;
                    if (activity4 != null) {
                        activity4.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda3
                            @Override // java.lang.Runnable
                            public final void run() {
                                M.c(this.f$0);
                            }
                        });
                        Unit unit4 = Unit.INSTANCE;
                    }
                    SubscriptionResponse subscriptionResponse2 = m.X;
                    String message = subscriptionResponse2 != null ? subscriptionResponse2.getMessage() : null;
                    Intrinsics.checkNotNull(message);
                    listener.onLicenseFailed(message);
                    return;
                }
                if (a(m.X)) {
                    Activity activity5 = m.f;
                    if (activity5 != null) {
                        activity5.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda1
                            @Override // java.lang.Runnable
                            public final void run() {
                                M.a(this.f$0);
                            }
                        });
                        Unit unit5 = Unit.INSTANCE;
                    }
                    listener.onLicenseFailed(ErrorMessageUtils.Error_13);
                    return;
                }
                Activity activity6 = m.f;
                if (activity6 != null) {
                    activity6.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda2
                        @Override // java.lang.Runnable
                        public final void run() {
                            M.b(this.f$0);
                        }
                    });
                    Unit unit6 = Unit.INSTANCE;
                }
                m.S.set(true);
                Unit unit7 = Unit.INSTANCE;
            }
            if (!m.p && !m.q) {
                m.a();
                listener.onFailure();
                return;
            }
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback");
            m.P = (ScanflowReader.OnBarcodeScanResultCallback) obj;
            m.n = cameraUserConfig.getAutoZoom();
            m.u = cameraUserConfig.isOneTouchZoomEnabled();
            m.N = cameraUserConfig.getSelectedResolution();
            ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
            scanflowLog.v("isOneTouchZoomEnabled", "isOneTouchZoomEnabled - " + m.u);
            SFCameraView sFCameraView = m.O;
            if (sFCameraView == null) {
                Intrinsics.throwUninitializedPropertyAccessException("sfCameraView");
                sFCameraView = null;
            }
            m.a(sFCameraView);
            scanflowLog.v("SFBarcode", "imageProxy to Bitmap - Started");
            Bitmap bitmapA = t.a(imageProxy);
            StringBuilder sb = new StringBuilder("imageProxy to Bitmap - Completed ");
            sb.append(bitmapA != null ? Integer.valueOf(bitmapA.getByteCount()) : null);
            scanflowLog.v("SFBarcode", sb.toString());
            Intrinsics.checkNotNull(bitmapA);
            Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmapA, imageProxy.getCropRect().left, imageProxy.getCropRect().top, imageProxy.getCropRect().width(), imageProxy.getCropRect().height());
            Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
            Bitmap bitmapA2 = t.a(bitmapCreateBitmap, imageProxy.getImageInfo().getRotationDegrees());
            Activity activity7 = m.f;
            int i = (activity7 == null || (resources = activity7.getResources()) == null || (configuration = resources.getConfiguration()) == null) ? 1 : configuration.orientation;
            m.j = t.a(bitmapA2.getWidth(), bitmapA2.getHeight(), 448, 448, i);
            Matrix matrix = new Matrix();
            m.k = matrix;
            Matrix matrix2 = m.j;
            if (matrix2 != null) {
                matrix2.invert(matrix);
            }
            Matrix matrixA = t.a(m.s, m.t, bitmapA2.getWidth(), bitmapA2.getHeight(), i);
            m.l = matrixA;
            matrixA.invert(matrixA);
            scanflowLog.v("SFBarcode", "About to start blur detection check");
            if (m.e != null) {
                scanflowLog.v("SFBarcode", "Blur Detection - Started");
                int rotationDegrees = imageProxy.getImageInfo().getRotationDegrees();
                C0089g c0089g = m.e;
                ArrayList arrayListA = c0089g != null ? c0089g.a(bitmapA2, rotationDegrees) : null;
                StringBuilder sb2 = new StringBuilder("Blur Detection - Completed ");
                sb2.append((arrayListA == null || (c0086d = (C0086d) arrayListA.get(0)) == null) ? null : c0086d.b);
                scanflowLog.v("SFBarcode", sb2.toString());
                if (arrayListA != null && !arrayListA.isEmpty() && !StringsKt.equals(((C0086d) arrayListA.get(0)).b, "sharp", true)) {
                    m.a();
                    listener.onFailure();
                    return;
                }
            } else {
                scanflowLog.v("SFBarcode", "Blur Detection - Skipped (classifier not available)");
            }
            scanflowLog.v("SFBarcode", "Blur detection check completed, proceeding to next step");
            scanflowLog.v("SFBarcode", "About to start low light detection");
            scanflowLog.v("SFBarcode", "Checking Low Light and image updated - Started");
            LowLightResponse lowLightResponseA = C0090h.a.a(bitmapA2);
            scanflowLog.v("SFBarcode", "Checking Low Light and image updated - Completed");
            try {
                if (lowLightResponseA == null) {
                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback2 = m.P;
                    if (onBarcodeScanResultCallback2 != null) {
                        onBarcodeScanResultCallback2.onScanBarcodeDetection(false);
                        Unit unit8 = Unit.INSTANCE;
                    }
                    m.a(listener);
                } else {
                    if (m.a.equals("dotmatrix_white") || m.a.equals("dotmatrix_metal")) {
                        int rotationDegrees2 = imageProxy.getImageInfo().getRotationDegrees();
                        int height = imageProxy.getHeight();
                        int width = imageProxy.getWidth();
                        int i2 = width / height;
                        Rect rect = new Rect(0, 0, width, height);
                        Pair pair = (Pair) m.a0.getValue();
                        if (i2 > 3) {
                            Intrinsics.checkNotNull(pair);
                            m.a0.setValue(new Pair(Integer.valueOf(((Number) pair.getFirst()).intValue() / 2), Integer.valueOf(((Number) pair.getSecond()).intValue())));
                        }
                        Pair pair2 = (Pair) m.a0.getValue();
                        Intrinsics.checkNotNull(pair2);
                        int iIntValue = ((Number) pair2.getFirst()).intValue();
                        int iIntValue2 = ((Number) pair2.getSecond()).intValue();
                        Pair pair3 = (rotationDegrees2 == 90 || rotationDegrees2 == 270) ? new Pair(Float.valueOf(iIntValue / 100.0f), Float.valueOf(iIntValue2 / 100.0f)) : new Pair(Float.valueOf(iIntValue2 / 100.0f), Float.valueOf(iIntValue / 100.0f));
                        float f = 2;
                        rect.inset((int) ((width * ((Number) pair3.component1()).floatValue()) / f), (int) ((height * ((Number) pair3.component2()).floatValue()) / f));
                        Bitmap bitmapSource = t.a(bitmapA, rotationDegrees2, rect);
                        Intrinsics.checkNotNull(bitmapSource);
                        if (bitmapSource != null) {
                            m.b(bitmapSource);
                            Unit unit9 = Unit.INSTANCE;
                        }
                        Bitmap bitmap = AbstractC0103s.a;
                        double d = m.a.equals("dotmatrix_white") ? 255.0d : 300.0d;
                        Intrinsics.checkNotNullParameter(bitmapSource, "bitmapSource");
                        Mat mat = new Mat();
                        Utils.bitmapToMat(bitmapSource, mat);
                        Mat mat2 = new Mat();
                        Imgproc.resize(mat, mat2, new com.scanflow.datacapture.barinternal.org.opencv.core.Size(d, d), 0.0d, 0.0d, 2);
                        int iCols = mat2.cols();
                        int iRows = mat2.rows();
                        Bitmap.Config config = Bitmap.Config.ARGB_8888;
                        Bitmap bitmapCreateBitmap2 = Bitmap.createBitmap(iCols, iRows, config);
                        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap2, "createBitmap(...)");
                        Utils.matToBitmap(mat2, bitmapCreateBitmap2);
                        if (bitmapCreateBitmap2 != null) {
                            Bitmap bitmapSource2 = m.a.equals("dotmatrix_white") ? r.b(bitmapCreateBitmap2) : r.a(bitmapCreateBitmap2);
                            double width2 = ((double) bitmapCreateBitmap2.getWidth()) / 4.0d;
                            double height2 = ((double) bitmapCreateBitmap2.getHeight()) / 4.0d;
                            Intrinsics.checkNotNullParameter(bitmapSource2, "bitmapSource");
                            Mat mat3 = new Mat();
                            Utils.bitmapToMat(bitmapSource2, mat3);
                            Mat mat4 = new Mat();
                            Imgproc.resize(mat3, mat4, new com.scanflow.datacapture.barinternal.org.opencv.core.Size(width2, height2), 0.0d, 0.0d, 2);
                            Bitmap bitmapCreateBitmap3 = Bitmap.createBitmap(mat4.cols(), mat4.rows(), config);
                            Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap3, "createBitmap(...)");
                            Utils.matToBitmap(mat4, bitmapCreateBitmap3);
                            InputImage inputImageFromBitmap = InputImage.fromBitmap(t.b(bitmapCreateBitmap3), 0);
                            Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap, "fromBitmap(...)");
                            AbstractC0094l.a.process(inputImageFromBitmap).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda4
                                @Override // com.google.android.gms.tasks.OnCompleteListener
                                public final void onComplete(Task task) {
                                    M.a(this.f$0, listener, task);
                                }
                            });
                            return;
                        }
                        return;
                    }
                    Log.v("SFBarcode", "image resize to 448 - Started");
                    Bitmap source = lowLightResponseA.getBitmap();
                    Intrinsics.checkNotNullParameter(source, "source");
                    int height3 = source.getHeight();
                    int width3 = source.getWidth();
                    Bitmap bitmapCreateBitmap4 = Bitmap.createBitmap(448, 448, Bitmap.Config.ARGB_8888);
                    Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap4, "createBitmap(...)");
                    Matrix matrixA2 = t.a(width3, height3, 448, 448, 0);
                    matrixA2.invert(new Matrix());
                    new Canvas(bitmapCreateBitmap4).drawBitmap(source, matrixA2, null);
                    Log.v("SFBarcode", "image resize to 448 - Completed");
                    Log.v("SFBarcode", "448 image to model - Started");
                    ArrayList arrayListA2 = m.a(bitmapCreateBitmap4);
                    Log.v("SFBarcode", "448 image to model - Completed " + arrayListA2.size());
                    v vVar = m.L;
                    if (vVar != null) {
                        LinkedList linkedList = new LinkedList();
                        System.currentTimeMillis();
                        vVar.a(linkedList);
                        Unit unit10 = Unit.INSTANCE;
                    }
                    if (arrayListA2.size() < 1) {
                        m.a();
                        if (m.n) {
                            CameraInfo cameraInfo = mCamera.getCameraInfo();
                            Float fValueOf = (cameraInfo == null || (zoomState6 = cameraInfo.getZoomState()) == null || (value6 = zoomState6.getValue()) == null) ? null : Float.valueOf(value6.getLinearZoom());
                            CameraInfo cameraInfo2 = mCamera.getCameraInfo();
                            Float fValueOf2 = (cameraInfo2 == null || (zoomState5 = cameraInfo2.getZoomState()) == null || (value5 = zoomState5.getValue()) == null) ? null : Float.valueOf(value5.getZoomRatio());
                            Intrinsics.checkNotNull(fValueOf2);
                            float fFloatValue = fValueOf2.floatValue();
                            CameraInfo cameraInfo3 = mCamera.getCameraInfo();
                            Float fValueOf3 = (cameraInfo3 == null || (zoomState4 = cameraInfo3.getZoomState()) == null || (value4 = zoomState4.getValue()) == null) ? null : Float.valueOf(value4.getMaxZoomRatio());
                            Intrinsics.checkNotNull(fValueOf3);
                            float fFloatValue2 = fValueOf3.floatValue();
                            if (fValueOf != null) {
                                if (fFloatValue != fFloatValue2 && !m.h) {
                                    float f2 = 0.01f;
                                    for (int i3 = 1; i3 < 16; i3++) {
                                        f2 += 0.01f;
                                        StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
                                        String str = String.format("%.2f", Arrays.copyOf(new Object[]{Float.valueOf(fValueOf.floatValue() + f2)}, 1));
                                        Intrinsics.checkNotNullExpressionValue(str, "format(...)");
                                        if (Float.parseFloat(str) <= 1.0f && (cameraControl = mCamera.getCameraControl()) != null) {
                                            cameraControl.setLinearZoom(Float.parseFloat(str));
                                        }
                                    }
                                } else if (fFloatValue >= fFloatValue2 && !m.h) {
                                    m.h = true;
                                    BuildersKt__Builders_commonKt.launch$default(GlobalScope.INSTANCE, Dispatchers.getIO().plus(m.m), null, new F(m, mCamera, null), 2, null);
                                }
                                Unit unit11 = Unit.INSTANCE;
                            } else {
                                m = m;
                                listener = listener;
                            }
                            onBarcodeScanResultCallback = m.P;
                            if (onBarcodeScanResultCallback != null) {
                                onBarcodeScanResultCallback.onScanBarcodeDetection(false);
                                Unit unit12 = Unit.INSTANCE;
                            }
                        } else {
                            if (m.u && !m.h) {
                                CameraInfo cameraInfo4 = mCamera.getCameraInfo();
                                Float fValueOf4 = (cameraInfo4 == null || (zoomState3 = cameraInfo4.getZoomState()) == null || (value3 = zoomState3.getValue()) == null) ? null : Float.valueOf(value3.getLinearZoom());
                                CameraInfo cameraInfo5 = mCamera.getCameraInfo();
                                Float fValueOf5 = (cameraInfo5 == null || (zoomState2 = cameraInfo5.getZoomState()) == null || (value2 = zoomState2.getValue()) == null) ? null : Float.valueOf(value2.getZoomRatio());
                                Intrinsics.checkNotNull(fValueOf5);
                                float fFloatValue3 = fValueOf5.floatValue();
                                CameraInfo cameraInfo6 = mCamera.getCameraInfo();
                                Float fValueOf6 = (cameraInfo6 == null || (zoomState = cameraInfo6.getZoomState()) == null || (value = zoomState.getValue()) == null) ? null : Float.valueOf(value.getMaxZoomRatio());
                                Intrinsics.checkNotNull(fValueOf6);
                                float fFloatValue4 = fValueOf6.floatValue();
                                Ref$FloatRef ref$FloatRef = new Ref$FloatRef();
                                ref$FloatRef.element = 0.01f;
                                if (fValueOf4 == null) {
                                    m = m;
                                    listener = listener;
                                } else if (fValueOf4.floatValue() < 1.0f) {
                                    ref$FloatRef.element = 0.01f;
                                    for (int i4 = 1; i4 < 26; i4++) {
                                        ref$FloatRef.element += 0.01f;
                                        StringCompanionObject stringCompanionObject2 = StringCompanionObject.INSTANCE;
                                        String str2 = String.format("%.2f", Arrays.copyOf(new Object[]{Float.valueOf(fValueOf4.floatValue() + ref$FloatRef.element)}, 1));
                                        Intrinsics.checkNotNullExpressionValue(str2, "format(...)");
                                        if (Float.parseFloat(str2) <= 1.0f) {
                                            CameraControl cameraControl2 = mCamera.getCameraControl();
                                            if (cameraControl2 != null) {
                                                cameraControl2.setLinearZoom(Float.parseFloat(str2));
                                            }
                                        } else {
                                            CameraControl cameraControl3 = mCamera.getCameraControl();
                                            if (cameraControl3 != null) {
                                                cameraControl3.setLinearZoom(1.0f);
                                            }
                                        }
                                    }
                                } else if (fFloatValue3 >= fFloatValue4 && !m.h) {
                                    listener.OnOneTouchCallbackDisable();
                                    Unit unit13 = Unit.INSTANCE;
                                    m.u = false;
                                    m.h = true;
                                    BuildersKt__Builders_commonKt.launch$default(GlobalScope.INSTANCE, Dispatchers.getIO().plus(m.m), null, new G(ref$FloatRef, fValueOf4, m, mCamera, listener, null), 2, null);
                                }
                                onBarcodeScanResultCallback = m.P;
                                if (onBarcodeScanResultCallback != null) {
                                    onBarcodeScanResultCallback.onScanBarcodeDetection(false);
                                    Unit unit14 = Unit.INSTANCE;
                                }
                            }
                            Unit unit15 = Unit.INSTANCE;
                            onBarcodeScanResultCallback = m.P;
                            if (onBarcodeScanResultCallback != null) {
                                onBarcodeScanResultCallback.onScanBarcodeDetection(false);
                                Unit unit16 = Unit.INSTANCE;
                            }
                        }
                    } else {
                        m = m;
                        listener = listener;
                        if (!m.b || arrayListA2.size() <= 0) {
                            if (m.c) {
                                Iterator it = arrayListA2.iterator();
                                Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
                                while (true) {
                                    if (!it.hasNext()) {
                                        c0084b2 = null;
                                        break;
                                    }
                                    Object next = it.next();
                                    Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                                    C0084b c0084b3 = (C0084b) next;
                                    float f3 = 224;
                                    if (c0084b3.d.contains(f3, f3)) {
                                        c0084b2 = c0084b3;
                                        break;
                                    }
                                }
                                if (c0084b2 != null) {
                                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback3 = m.P;
                                    if (onBarcodeScanResultCallback3 != null) {
                                        onBarcodeScanResultCallback3.onScanBarcodeDetection(true);
                                        Unit unit17 = Unit.INSTANCE;
                                    }
                                    m.a(c0084b2, lowLightResponseA, listener);
                                } else {
                                    m.a();
                                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback4 = m.P;
                                    if (onBarcodeScanResultCallback4 != null) {
                                        onBarcodeScanResultCallback4.onScanBarcodeDetection(false);
                                        Unit unit18 = Unit.INSTANCE;
                                    }
                                    m.a(listener);
                                }
                            } else {
                                Iterator it2 = arrayListA2.iterator();
                                Intrinsics.checkNotNullExpressionValue(it2, "iterator(...)");
                                while (true) {
                                    if (!it2.hasNext()) {
                                        c0084b = null;
                                        break;
                                    }
                                    Object next2 = it2.next();
                                    Intrinsics.checkNotNullExpressionValue(next2, "next(...)");
                                    C0084b c0084b4 = (C0084b) next2;
                                    float f4 = 224;
                                    if (c0084b4.d.contains(f4, f4)) {
                                        c0084b = c0084b4;
                                        break;
                                    }
                                }
                                if (c0084b != null) {
                                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback5 = m.P;
                                    if (onBarcodeScanResultCallback5 != null) {
                                        onBarcodeScanResultCallback5.onScanBarcodeDetection(true);
                                        Unit unit19 = Unit.INSTANCE;
                                    }
                                    m.a(c0084b, lowLightResponseA, listener);
                                } else {
                                    m.a();
                                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback6 = m.P;
                                    if (onBarcodeScanResultCallback6 != null) {
                                        onBarcodeScanResultCallback6.onScanBarcodeDetection(false);
                                        Unit unit20 = Unit.INSTANCE;
                                    }
                                    m.a(listener);
                                }
                            }
                            Unit unit21 = Unit.INSTANCE;
                        } else {
                            ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback7 = m.P;
                            if (onBarcodeScanResultCallback7 != null) {
                                onBarcodeScanResultCallback7.onScanBarcodeDetection(true);
                                Unit unit22 = Unit.INSTANCE;
                            }
                            m.Q = new ArrayList();
                            Iterator it3 = arrayListA2.iterator();
                            Intrinsics.checkNotNullExpressionValue(it3, "iterator(...)");
                            while (it3.hasNext()) {
                                Object next3 = it3.next();
                                Intrinsics.checkNotNullExpressionValue(next3, "next(...)");
                                C0084b c0084b5 = (C0084b) next3;
                                RectF rectF = c0084b5.d;
                                Matrix matrix3 = m.k;
                                Intrinsics.checkNotNull(matrix3);
                                matrix3.mapRect(rectF);
                                Intrinsics.checkNotNullParameter(rectF, "<set-?>");
                                c0084b5.d = rectF;
                                m.B.add(c0084b5);
                                Bitmap bitmapA3 = a(lowLightResponseA.getBitmap(), c0084b5.d);
                                if (bitmapA3 != null) {
                                    m.Q.add(new B(bitmapA3, c0084b5.d));
                                }
                            }
                            if (m.Q.size() > 0) {
                                BuildersKt__BuildersKt.runBlocking$default(null, new H(m, listener, null), 1, null);
                            } else {
                                m.a();
                            }
                        }
                    }
                    m.a(listener);
                }
                Unit unit23 = Unit.INSTANCE;
            } catch (Exception unused) {
            }
        } catch (Exception unused2) {
        }
    }

    @Override // androidx.lifecycle.LifecycleOwner
    public final Lifecycle getLifecycle() {
        return this.w;
    }

    public static final void a(M this$0, Analyzer.OnAnalyzeListener listener, Task it) {
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(listener, "$listener");
        Intrinsics.checkNotNullParameter(it, "it");
        if (it.isSuccessful() && ((List) it.getResult()).size() > 0 && ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue() != null) {
            String displayValue = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
            Intrinsics.checkNotNull(displayValue);
            if (displayValue.length() != 0) {
                ScanflowLog.INSTANCE.v("qrResult", "qrResult ML- " + ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue());
                String displayValue2 = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
                Intrinsics.checkNotNull(displayValue2);
                ScanResultSuccess scanResultSuccess = new ScanResultSuccess(displayValue2, BarcodeFormat.QR_CODE, true, new ArrayList(), new RectF(), "QR_CODE");
                BeepManager beepManager = this$0.M;
                if (beepManager != null) {
                    beepManager.playBeepSoundAndVibrate();
                }
                ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this$0.P;
                if (onBarcodeScanResultCallback != null) {
                    onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                }
                this$0.x = new ArrayList();
                listener.onSuccess("Scanned");
                return;
            }
        }
        ScanflowLog.INSTANCE.v("qrResult", "qrResult - failed");
        this$0.a(listener);
    }

    public final void b(Bitmap bitmap) {
        StorageUtils storageUtils = StorageUtils.INSTANCE;
        Activity activity = this.f;
        Intrinsics.checkNotNull(activity);
        Uri uriAddBitmapToStorage = storageUtils.addBitmapToStorage(bitmap, activity, "BarcodeOrginal", null);
        if (uriAddBitmapToStorage != null) {
            Activity activity2 = this.f;
            Intrinsics.checkNotNull(activity2);
            storageUtils.getPath(activity2, uriAddBitmapToStorage);
        }
    }

    public static double a(Point p1, Point p2) {
        Intrinsics.checkNotNullParameter(p1, "p1");
        Intrinsics.checkNotNullParameter(p2, "p2");
        double degrees = Math.toDegrees(Math.atan2(p1.y - p2.y, p2.x - p1.x));
        return degrees < 0.0d ? degrees + 360.0d : degrees;
    }

    public final synchronized void b() {
        try {
            try {
                v vVar = this.L;
                if (vVar != null) {
                    LinkedList linkedList = this.B;
                    System.currentTimeMillis();
                    vVar.a(linkedList);
                }
                Activity activity = this.f;
                if (activity != null) {
                    activity.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda12
                        @Override // java.lang.Runnable
                        public final void run() {
                            M.j(this.f$0);
                        }
                    });
                }
                ScanflowLog.INSTANCE.v("SFBarcode", "Bounding Box Updated");
            } catch (Exception e) {
                e.printStackTrace();
            }
        } catch (Throwable th) {
            throw th;
        }
    }

    public final void a(ArOverlayView arOverlays) {
        Intrinsics.checkNotNullParameter(arOverlays, "arOverlays");
        Activity activity = this.f;
        Intrinsics.checkNotNull(activity);
        final BoundingBoxArOverlay boundingBoxArOverlay = new BoundingBoxArOverlay(activity, false);
        this.C.postValue(arOverlays);
        this.D.observe(this, new Observer() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda9
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                M.a(boundingBoxArOverlay, this, (ArOverlayView) obj);
            }
        });
        arOverlays.setOnTouchListener(new I(this));
    }

    public static final void a(BoundingBoxArOverlay boundingBoxArOverlay, M this$0, ArOverlayView arOverlayView) {
        Intrinsics.checkNotNullParameter(boundingBoxArOverlay, "$boundingBoxArOverlay");
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNull(arOverlayView);
        if (!ViewCompat.isLaidOut(arOverlayView) || arOverlayView.isLayoutRequested()) {
            arOverlayView.addOnLayoutChangeListener(new J(this$0, boundingBoxArOverlay));
        } else {
            this$0.G.pipe(new x(arOverlayView.getWidth(), arOverlayView.getHeight())).pipe(new w()).addTrackingListener(boundingBoxArOverlay);
        }
        arOverlayView.add(boundingBoxArOverlay);
    }

    /* JADX WARN: Code duplicated, block: B:14:0x0050  */
    /* JADX WARN: Code duplicated, block: B:15:0x0052  */
    public final D a(Bitmap bitmap, String str) {
        boolean z;
        D d = D.INITIAL;
        if (str.equals("qr_code")) {
            int width = bitmap.getWidth();
            int height = bitmap.getHeight();
            int i = this.s;
            int i2 = this.t;
            float f = 100;
            if ((width / i) * f < 13.0f || (height / i2) * f < 9.0f) {
                z = true;
            } else {
                z = false;
            }
        } else {
            int width2 = bitmap.getWidth();
            int height2 = bitmap.getHeight();
            int i3 = this.s;
            int i4 = this.t;
            float f2 = 100;
            if ((width2 / i3) * f2 < 64.0f || (height2 / i4) * f2 < 16.0f) {
                z = true;
            } else {
                z = false;
            }
        }
        ScanflowLog.INSTANCE.v("SFBarcode", "IsLongDistanceImage: " + z);
        return z ? D.LONG_DISTANCE : D.TILT;
    }

    public static Bitmap a(Bitmap bitmap, RectF rectF) {
        float f = rectF.left;
        float f2 = 25;
        float f3 = f - f2;
        if (f3 > 0.0f) {
            f = f3;
        }
        float f4 = rectF.top;
        float f5 = f4 - f2;
        if (f5 > 0.0f) {
            f4 = f5;
        }
        try {
            if (f <= 0.0f || f4 <= 0.0f) {
                Intrinsics.checkNotNull(bitmap);
                return Bitmap.createBitmap(bitmap, (int) rectF.left, (int) rectF.top, (int) rectF.width(), (int) rectF.height());
            }
            Intrinsics.checkNotNull(bitmap);
            return Bitmap.createBitmap(bitmap, (int) f, (int) f4, ((int) rectF.width()) + 50, ((int) rectF.height()) + (((int) rectF.height()) / 2));
        } catch (Exception unused) {
            return null;
        }
    }

    public final String a(String str) {
        StringBuilder sb;
        try {
            byte[] bArrDecode = Base64.getDecoder().decode(str);
            Intrinsics.checkNotNull(bArrDecode);
            byte[] bArrCopyOfRange = ArraysKt.copyOfRange(bArrDecode, 0, 12);
            byte[] bArrCopyOfRange2 = ArraysKt.copyOfRange(bArrDecode, 12, bArrDecode.length);
            GCMParameterSpec gCMParameterSpec = new GCMParameterSpec(128, bArrCopyOfRange);
            SecretKeyFactory secretKeyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256");
            SharedPreferences sharedPreferences = this.T;
            if (sharedPreferences == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                sharedPreferences = null;
            }
            char[] charArray = String.valueOf(sharedPreferences.getString(this.U, "")).toCharArray();
            Intrinsics.checkNotNullExpressionValue(charArray, "toCharArray(...)");
            SharedPreferences sharedPreferences2 = this.T;
            if (sharedPreferences2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                sharedPreferences2 = null;
            }
            String strValueOf = String.valueOf(sharedPreferences2.getString(this.V, ""));
            Charset charset = Charsets.UTF_8;
            byte[] bytes = strValueOf.getBytes(charset);
            Intrinsics.checkNotNullExpressionValue(bytes, "getBytes(...)");
            SecretKeySpec secretKeySpec = new SecretKeySpec(secretKeyFactory.generateSecret(new PBEKeySpec(charArray, bytes, 65536, 256)).getEncoded(), "AES");
            Cipher cipher = Cipher.getInstance("AES/GCM/NoPadding");
            cipher.init(2, secretKeySpec, gCMParameterSpec);
            byte[] bArrDoFinal = cipher.doFinal(bArrCopyOfRange2);
            Intrinsics.checkNotNullExpressionValue(bArrDoFinal, "doFinal(...)");
            return new String(bArrDoFinal, charset);
        } catch (InvalidAlgorithmParameterException e) {
            e = e;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (InvalidKeyException e2) {
            e = e2;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (NoSuchAlgorithmException e3) {
            e = e3;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (InvalidKeySpecException e4) {
            e = e4;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (BadPaddingException e5) {
            e = e5;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (IllegalBlockSizeException e6) {
            e = e6;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        } catch (NoSuchPaddingException e7) {
            e = e7;
            sb = new StringBuilder("Error occured during decryption: ");
            sb.append(e);
            System.out.println((Object) sb.toString());
            return null;
        }
    }

    public final synchronized ArrayList a(Bitmap bitmap) {
        ArrayList arrayList = new ArrayList();
        N n = this.g;
        if (n != null && bitmap != null) {
            Intrinsics.checkNotNull(n);
            ArrayList arrayListA = n.a(bitmap);
            Log.d("SFBarcode", "TFLite Model results Size: " + arrayListA.size() + " Result:  " + arrayListA);
            this.B.clear();
            if (arrayListA.size() == 0) {
                bitmap.recycle();
                return arrayList;
            }
            Iterator it = arrayListA.iterator();
            Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
            while (it.hasNext()) {
                Object next = it.next();
                Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                C0084b result = (C0084b) next;
                String scanType = this.a;
                if (scanType == null) {
                    scanType = "";
                }
                Intrinsics.checkNotNullParameter(result, "result");
                Intrinsics.checkNotNullParameter(scanType, "scanType");
                if (result.c >= 0.2f && (Intrinsics.areEqual(result.b, scanType) || Intrinsics.areEqual(scanType, "any"))) {
                    arrayList.add(result);
                }
            }
            return arrayList;
        }
        return arrayList;
    }

    public static BarcodeFormat a(int i) {
        if (i == 1) {
            return BarcodeFormat.CODE_128;
        }
        if (i == 2) {
            return BarcodeFormat.CODE_39;
        }
        switch (i) {
            case 4:
                return BarcodeFormat.CODE_93;
            case 8:
                return BarcodeFormat.CODABAR;
            case 16:
                return BarcodeFormat.DATA_MATRIX;
            case 32:
                return BarcodeFormat.EAN_13;
            case 64:
                return BarcodeFormat.EAN_8;
            case 128:
                return BarcodeFormat.ITF;
            case 256:
                return BarcodeFormat.QR_CODE;
            case 512:
                return BarcodeFormat.UPC_A;
            case 1024:
                return BarcodeFormat.UPC_E;
            case 2048:
                return BarcodeFormat.PDF_417;
            case 4096:
                return BarcodeFormat.AZTEC;
            default:
                return BarcodeFormat.CODE_128;
        }
    }

    /* JADX WARN: Code duplicated, block: B:13:0x0060  */
    public static boolean a(SubscriptionResponse subscriptionResponse) throws ParseException {
        Date date;
        Result result;
        String subscriptionEndDate;
        SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
        if (subscriptionResponse == null || (result = subscriptionResponse.getResult()) == null || (subscriptionEndDate = result.getSubscriptionEndDate()) == null) {
            date = null;
        } else {
            TimeZone timeZone = TimeZone.getTimeZone("UTC");
            Intrinsics.checkNotNullParameter(subscriptionEndDate, "<this>");
            Intrinsics.checkNotNullParameter("yyyy-MM-dd'T'HH:mm:ss.SSS", "dateFormat");
            Intrinsics.checkNotNullParameter(timeZone, "timeZone");
            SimpleDateFormat simpleDateFormat2 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS", Locale.getDefault());
            simpleDateFormat2.setTimeZone(timeZone);
            Date date2 = simpleDateFormat2.parse(subscriptionEndDate);
            if (date2 != null) {
                TimeZone timeZone2 = TimeZone.getDefault();
                Intrinsics.checkNotNullParameter(date2, "<this>");
                Intrinsics.checkNotNullParameter("yyyy-MM-dd'T'HH:mm:ss.SSS", "dateFormat");
                Intrinsics.checkNotNullParameter(timeZone2, "timeZone");
                SimpleDateFormat simpleDateFormat3 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS", Locale.getDefault());
                simpleDateFormat3.setTimeZone(timeZone2);
                String str = simpleDateFormat3.format(date2);
                if (str != null) {
                    date = simpleDateFormat.parse(str);
                } else {
                    date = null;
                }
            } else {
                date = null;
            }
        }
        return new Date(System.currentTimeMillis()).after(date);
    }

    public static void a(C0084b c0084b, ScanResultSuccess scanResultSuccess, int i) {
        if (scanResultSuccess.getPoints().size() > 0) {
            float f = i;
            c0084b.e = new PointF((scanResultSuccess.getPoints().get(0).x / f) + c0084b.d.left, (scanResultSuccess.getPoints().get(0).y / f) + c0084b.d.top);
            new PointF((scanResultSuccess.getPoints().get(1).x / f) + c0084b.d.left, (scanResultSuccess.getPoints().get(1).y / f) + c0084b.d.top);
            new PointF((scanResultSuccess.getPoints().get(2).x / f) + c0084b.d.left, (scanResultSuccess.getPoints().get(2).y / f) + c0084b.d.top);
            new PointF((scanResultSuccess.getPoints().get(3).x / f) + c0084b.d.left, (scanResultSuccess.getPoints().get(3).y / f) + c0084b.d.top);
        }
    }

    public final void a(ArrayList batchScanningResultList, Analyzer.OnAnalyzeListener listener) {
        int color;
        String displayValue;
        Intrinsics.checkNotNullParameter(batchScanningResultList, "batchScanningResultList");
        Intrinsics.checkNotNullParameter(listener, "listener");
        if (batchScanningResultList.size() <= 0) {
            a();
            a(listener);
            return;
        }
        ArrayList<ScanResultSuccess> arrayList = new ArrayList<>();
        this.F = new ArrayList();
        this.B.clear();
        Iterator it = batchScanningResultList.iterator();
        Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
        while (it.hasNext()) {
            Object next = it.next();
            Intrinsics.checkNotNullExpressionValue(next, "next(...)");
            C c = (C) next;
            ArrayList arrayList2 = new ArrayList();
            Barcode barcode = c.b;
            if (barcode != null) {
                if (c.c == null) {
                    if (barcode.getDisplayValue() != null) {
                        String displayValue2 = barcode.getDisplayValue();
                        Intrinsics.checkNotNull(displayValue2);
                        if (displayValue2.length() == 0) {
                        }
                    }
                }
                String string = c.c;
                if (string == null) {
                    String displayValue3 = barcode.getDisplayValue();
                    Intrinsics.checkNotNull(displayValue3);
                    string = StringsKt.trimStart(StringsKt.replace$default(displayValue3, "\u001d", " ", false, 4, (Object) null)).toString();
                }
                BarcodeFormat barcodeFormatA = a(barcode.getFormat());
                RectF rectF = c.a;
                Intrinsics.checkNotNull(rectF);
                arrayList.add(new ScanResultSuccess(string, barcodeFormatA, false, arrayList2, rectF, this.r));
                String displayValue4 = barcode.getDisplayValue();
                Intrinsics.checkNotNull(displayValue4);
                OneOFManyCodesScanResults oneOFManyCodesScanResults = new OneOFManyCodesScanResults(displayValue4, a(barcode.getFormat()).name());
                String displayValue5 = barcode.getDisplayValue();
                Intrinsics.checkNotNull(displayValue5);
                C0084b c0084b = new C0084b(displayValue5, a(barcode.getFormat()).name(), 0.5f, c.a);
                if (!this.d || this.J.contains(oneOFManyCodesScanResults)) {
                    color = Color.parseColor("#1ab3fb");
                } else {
                    color = Color.parseColor("#FFFFFF");
                }
                c0084b.f = color;
                if (c.b.getFormat() == 2) {
                    displayValue = c.c;
                } else {
                    Barcode barcode2 = c.b;
                    displayValue = barcode2 != null ? barcode2.getDisplayValue() : null;
                }
                String str = displayValue;
                if (str != null) {
                    if (c.a != null && str.length() != 0 && (!this.b0.contains(str) || this.d)) {
                        Log.v("batchScanningResult", "scannedMatrixDataList.contains(it): " + this.b0.contains(str) + ' ' + this.d);
                        Log.v("batchScanningResult", "batchScanningResult: " + c.a + ' ' + c.c);
                        ArrayList arrayList3 = this.F;
                        Matrix previewToCropTransform = this.l;
                        RectF yolov4location = c0084b.d;
                        Intrinsics.checkNotNullParameter(previewToCropTransform, "previewToCropTransform");
                        Intrinsics.checkNotNullParameter(yolov4location, "yolov4location");
                        previewToCropTransform.mapRect(yolov4location);
                        arrayList3.add(new ArObject(str, yolov4location, this.N, 0, c0084b.f, oneOFManyCodesScanResults, !this.d));
                    }
                    this.b0.add(str);
                }
                this.B.add(c0084b);
            }
        }
        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this.P;
        if (onBarcodeScanResultCallback != null) {
            onBarcodeScanResultCallback.onBatchScanResultSuccess(arrayList);
        }
        this.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda5
            @Override // java.lang.Runnable
            public final void run() {
                M.e(this.f$0);
            }
        });
        b();
        listener.onSuccess("Scanned");
    }

    public final void a(final Bitmap bitmap, final boolean z, final RectF rectF, final C0084b c0084b, final Analyzer.OnAnalyzeListener onAnalyzeListener) {
        Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap, 0, bitmap.getHeight() / 2, bitmap.getWidth(), bitmap.getHeight() / 2);
        Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
        TextRecognizerOptions textRecognizerOptions = TextRecognizerOptions.DEFAULT_OPTIONS;
        TextRecognizer client = TextRecognition.getClient(new TextRecognizerOptions.Builder().setExecutor(this.i).build());
        Intrinsics.checkNotNullExpressionValue(client, "getClient(...)");
        Task<Text> taskProcess = client.process(InputImage.fromBitmap(bitmapCreateBitmap, 0));
        final Function1 function1 = new Function1() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda13
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return M.a(onAnalyzeListener, this, z, rectF, c0084b, bitmap, (Text) obj);
            }
        };
        taskProcess.addOnSuccessListener(new OnSuccessListener() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda14
            @Override // com.google.android.gms.tasks.OnSuccessListener
            public final void onSuccess(Object obj) {
                M.a(function1, obj);
            }
        }).addOnFailureListener(new OnFailureListener() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda15
            @Override // com.google.android.gms.tasks.OnFailureListener
            public final void onFailure(Exception exc) {
                M.a(onAnalyzeListener, exc);
            }
        });
    }

    /* JADX WARN: Code duplicated, block: B:105:0x0470  */
    /* JADX WARN: Multi-variable type inference failed */
    /* JADX WARN: Type inference failed for: r10v36 */
    /* JADX WARN: Type inference failed for: r10v37 */
    /* JADX WARN: Type inference failed for: r10v40 */
    /* JADX WARN: Type inference failed for: r10v41 */
    /* JADX WARN: Type inference failed for: r12v17 */
    /* JADX WARN: Type inference failed for: r12v18, types: [int] */
    /* JADX WARN: Type inference failed for: r12v21 */
    public static final Unit a(Analyzer.OnAnalyzeListener listener, final M this$0, boolean z, RectF location, C0084b result, Bitmap croppedBitmap, Text text) {
        String text2;
        double d;
        StringBuilder sb;
        boolean z2;
        Object obj;
        Object string;
        Intrinsics.checkNotNullParameter(listener, "$listener");
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(location, "$location");
        Intrinsics.checkNotNullParameter(result, "$result");
        Intrinsics.checkNotNullParameter(croppedBitmap, "$croppedBitmap");
        String text3 = text.getText();
        if (text3 == null || text3.length() == 0) {
            listener.onFailure();
        } else {
            List<Text.TextBlock> textBlocks = text.getTextBlocks();
            Intrinsics.checkNotNullExpressionValue(textBlocks, "getTextBlocks(...)");
            this$0.getClass();
            ArrayList arrayList = new ArrayList();
            Iterator<Text.TextBlock> it = textBlocks.iterator();
            while (it.hasNext()) {
                arrayList.add(it.next());
            }
            Log.v("refinedResult", "data " + arrayList.size());
            for (int i = 0; i < arrayList.size(); i++) {
                Log.v("refinedResult", "Before " + ((Text.TextBlock) arrayList.get(i)).getText() + " " + ((Text.TextBlock) arrayList.get(i)).getBoundingBox());
            }
            String str = "";
            if (arrayList.size() == 1) {
                text2 = ((Text.TextBlock) arrayList.get(0)).getText();
            } else {
                Collections.sort(arrayList, new P());
                ArrayList arrayList2 = new ArrayList();
                ArrayList arrayList3 = new ArrayList();
                double d2 = ((Text.TextBlock) arrayList.get(0)).getBoundingBox().top - 10;
                int i2 = 1;
                double d3 = ((Text.TextBlock) arrayList.get(0)).getBoundingBox().top + 10;
                String string2 = "";
                for (int i3 = 0; i3 < arrayList.size(); i3++) {
                    if (i3 == 0) {
                        arrayList3.add((Text.TextBlock) arrayList.get(i3));
                        d = d3;
                        Log.v("refinedResult", "if (idx == 0) " + ((Text.TextBlock) arrayList.get(i3)).getText());
                        sb = new StringBuilder();
                        sb.append(string2);
                    } else {
                        d = d3;
                        if (((Text.TextBlock) arrayList.get(i3)).getBoundingBox().top < d2 || ((Text.TextBlock) arrayList.get(i3)).getBoundingBox().top > d) {
                            arrayList2.add(new ArrayList(arrayList3));
                            ArrayList arrayList4 = new ArrayList();
                            arrayList4.add((Text.TextBlock) arrayList.get(i3));
                            Log.v("refinedResult", "else.get(idx).getBoundingBox().top " + ((Text.TextBlock) arrayList.get(i3)).getText());
                            string2 = string2 + "\n" + ((Text.TextBlock) arrayList.get(i3)).getText();
                            d2 = ((Text.TextBlock) arrayList.get(i3)).getBoundingBox().top - 10;
                            d3 = ((Text.TextBlock) arrayList.get(i3)).getBoundingBox().top + 10;
                            arrayList3 = arrayList4;
                        } else {
                            arrayList3.add((Text.TextBlock) arrayList.get(i3));
                            Log.v("refinedResult", "data.get(idx).getBoundingBox().top " + ((Text.TextBlock) arrayList.get(i3)).getText());
                            sb = new StringBuilder();
                            sb.append(string2);
                            sb.append("");
                        }
                        if (i3 != arrayList.size() - 1 && !arrayList3.isEmpty()) {
                            arrayList2.add(new ArrayList(arrayList3));
                        }
                    }
                    sb.append(((Text.TextBlock) arrayList.get(i3)).getText());
                    string2 = sb.toString();
                    d3 = d;
                    if (i3 != arrayList.size() - 1) {
                    }
                }
                Log.v("refinedResult", "- - " + string2);
                Log.v("refinedResult", "line " + arrayList3.size());
                ArrayList arrayList5 = new ArrayList();
                int size = arrayList2.size();
                int i4 = 0;
                while (i4 < size) {
                    Object obj2 = arrayList2.get(i4);
                    i4++;
                    ArrayList arrayList6 = (ArrayList) obj2;
                    if (arrayList6.size() > i2) {
                        Collections.sort(arrayList6, new O());
                    }
                    arrayList5.add(arrayList6);
                    i2 = 1;
                }
                Log.v("refinedResult", "finalData " + arrayList5.size());
                text2 = "";
                for (int i5 = 0; i5 < arrayList5.size(); i5++) {
                    for (int i6 = 0; i6 < ((ArrayList) arrayList5.get(i5)).size(); i6++) {
                        text2 = text2 + "\n" + ((Text.TextBlock) ((ArrayList) arrayList5.get(i5)).get(i6)).getText();
                    }
                    System.out.println("--------------------");
                }
                System.out.println("finalrefinedOutput---before-----" + text2);
                Log.v("refinedResult", "-final- " + text2);
            }
            String text4 = text2;
            if (text4 == null || text4.length() == 0) {
                listener.onFailure();
            } else {
                Intrinsics.checkNotNullParameter(text4, "text");
                List<String> text5 = StringsKt.split$default((CharSequence) text4, new String[]{"\n"}, false, 0, 6, (Object) null);
                Intrinsics.checkNotNullParameter(text5, "text");
                ArrayList arrayList7 = new ArrayList();
                for (String str2 : text5) {
                    if (str2 != null && str2.length() != 0 && !str2.equals("-") && !str2.equals("*") && !str2.equals("%")) {
                        arrayList7.add(StringsKt.trim(str2).toString());
                    }
                }
                if (arrayList7.size() > 0) {
                    z2 = false;
                    obj = arrayList7.get(0);
                } else {
                    z2 = false;
                    obj = text4;
                }
                CharSequence charSequence = (CharSequence) obj;
                if (charSequence == null || charSequence.length() == 0) {
                    listener.onFailure();
                } else {
                    String str3 = (String) obj;
                    if (StringsKt.startsWith$default(str3, "-", z2, 2, (Object) null)) {
                        string = obj;
                        string = StringsKt.trim(StringsKt.replaceFirst$default(str3, "-", "", false, 4, null)).toString();
                    }
                    string = obj;
                    this$0.x.add(string);
                    String str4 = (String) string;
                    Log.v("barcodeText", str4);
                    ArrayList scannedResut = this$0.x;
                    Intrinsics.checkNotNullParameter(scannedResut, "scannedResut");
                    HashMap map = new HashMap();
                    Iterator it2 = scannedResut.iterator();
                    Intrinsics.checkNotNullExpressionValue(it2, "iterator(...)");
                    ?? r10 = z2;
                    while (it2.hasNext()) {
                        Object next = it2.next();
                        Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                        String str5 = (String) next;
                        Integer num = (Integer) map.get(str5);
                        int iIntValue = (num != null ? num.intValue() : z2) + 1;
                        map.put(str5, Integer.valueOf(iIntValue));
                        if (iIntValue > r10) {
                            str = str5;
                            r10 = iIntValue;
                        }
                    }
                    Pair pair = new Pair(Integer.valueOf(r10 == true ? 1 : 0), str);
                    String str6 = ((Number) pair.getFirst()).intValue() >= this$0.y ? (String) pair.getSecond() : null;
                    if (str6 != null) {
                        Log.v("barcodeText", "barcodeText MOST - ".concat(str6));
                        ScanResultSuccess scanResultSuccess = new ScanResultSuccess(str4, a(1), z, new ArrayList(), location, "bar_code");
                        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this$0.P;
                        if (onBarcodeScanResultCallback != null) {
                            onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                        }
                        this$0.x = new ArrayList();
                        ArrayList arrayList8 = new ArrayList();
                        this$0.F = arrayList8;
                        String text6 = scanResultSuccess.getText();
                        Matrix previewToCropTransform = this$0.l;
                        RectF yolov4location = result.d;
                        Intrinsics.checkNotNullParameter(previewToCropTransform, "previewToCropTransform");
                        Intrinsics.checkNotNullParameter(yolov4location, "yolov4location");
                        previewToCropTransform.mapRect(yolov4location);
                        arrayList8.add(new ArObject(text6, yolov4location, this$0.N, 0, Color.parseColor("#1ab3fb"), null, false));
                        this$0.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda8
                            @Override // java.lang.Runnable
                            public final void run() {
                                M.f(this.f$0);
                            }
                        });
                        this$0.B.add(result);
                        this$0.b();
                        croppedBitmap.recycle();
                        BeepManager beepManager = this$0.M;
                        if (beepManager != null) {
                            beepManager.playBeepSoundAndVibrate();
                        }
                        listener.onSuccess("Success");
                    } else {
                        listener.onFailure();
                    }
                }
            }
        }
        return Unit.INSTANCE;
    }

    public static final void a(Function1 tmp0, Object obj) {
        Intrinsics.checkNotNullParameter(tmp0, "$tmp0");
        tmp0.invoke(obj);
    }

    public static final void a(Analyzer.OnAnalyzeListener listener, Exception exception) {
        Intrinsics.checkNotNullParameter(listener, "$listener");
        Intrinsics.checkNotNullParameter(exception, "exception");
        listener.onFailure();
    }

    public final void a(final Bitmap bitmap, final C0084b c0084b, final boolean z, final int i, final String str, final Analyzer.OnAnalyzeListener onAnalyzeListener) {
        Log.v("SFBarcode", "decodeML - Started");
        InputImage inputImageFromBitmap = InputImage.fromBitmap(t.a(bitmap), 0);
        Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap, "fromBitmap(...)");
        AbstractC0094l.a.process(inputImageFromBitmap).addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda6
            @Override // com.google.android.gms.tasks.OnCompleteListener
            public final void onComplete(Task task) {
                M.a(z, bitmap, this, str, c0084b, onAnalyzeListener, i, task);
            }
        });
    }

    /* JADX WARN: Code duplicated, block: B:63:0x03be  */
    /* JADX WARN: Code duplicated, block: B:70:0x03fa A[DONT_INVERT] */
    /* JADX WARN: Code duplicated, block: B:71:0x03fc  */
    /* JADX WARN: Code duplicated, block: B:79:0x0427  */
    /* JADX WARN: Code duplicated, block: B:81:0x042b  */
    /* JADX WARN: Code duplicated, block: B:85:0x0439  */
    /* JADX WARN: Code duplicated, block: B:87:0x048d  */
    /* JADX WARN: Code restructure failed: missing block: B:101:?, code lost:
    
        return;
     */
    /* JADX WARN: Code restructure failed: missing block: B:88:0x0491, code lost:
    
        if (r41.equals("bar_code") != false) goto L92;
     */
    /* JADX WARN: Code restructure failed: missing block: B:91:0x0498, code lost:
    
        if (r41.equals("bar_code") != false) goto L92;
     */
    /* JADX WARN: Code restructure failed: missing block: B:92:0x049a, code lost:
    
        r40.a(r39, r38, r42.d, r42, r43);
     */
    /* JADX WARN: Code restructure failed: missing block: B:93:0x04a2, code lost:
    
        r40.a(r43);
     */
    /* JADX WARN: Code restructure failed: missing block: B:94:0x04a5, code lost:
    
        return;
     */
    /* JADX WARN: Multi-variable type inference failed */
    /*
        Code decompiled incorrectly, please refer to instructions dump.
    */
    public static final void a(boolean z, Bitmap croppedBitmap, final M this$0, String barcodeType, C0084b result, Analyzer.OnAnalyzeListener listener, int i, Task it) {
        char c;
        int i2;
        int i3;
        String str;
        double dA;
        int i4;
        String displayValue;
        ScanResultSuccess scanResultSuccess;
        boolean z2;
        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback;
        BeepManager beepManager;
        String text;
        Point point;
        Point point2;
        Intrinsics.checkNotNullParameter(croppedBitmap, "$croppedBitmap");
        Intrinsics.checkNotNullParameter(this$0, "this$0");
        Intrinsics.checkNotNullParameter(barcodeType, "$barcodeType");
        Intrinsics.checkNotNullParameter(result, "$result");
        Intrinsics.checkNotNullParameter(listener, "$listener");
        Intrinsics.checkNotNullParameter(it, "it");
        if (it.isSuccessful() && ((List) it.getResult()).size() > 0 && ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue() != null) {
            String displayValue2 = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
            Intrinsics.checkNotNull(displayValue2);
            if (displayValue2.length() != 0) {
                int format = ((Barcode) ((List) it.getResult()).get(0)).getFormat();
                ArrayList arrayList = new ArrayList();
                int i5 = z ? 2 : 1;
                Point[] cornerPoints = ((Barcode) ((List) it.getResult()).get(0)).getCornerPoints();
                if (cornerPoints != null) {
                    c = 1;
                    i2 = 2;
                    Point point3 = cornerPoints[0];
                    arrayList.add(new PointF(new Point(point3.x / i5, point3.y / i5)));
                    Point point4 = cornerPoints[1];
                    arrayList.add(new PointF(new Point(point4.x / i5, point4.y / i5)));
                    Point point5 = cornerPoints[2];
                    arrayList.add(new PointF(new Point(point5.x / i5, point5.y / i5)));
                    Point point6 = cornerPoints[3];
                    arrayList.add(new PointF(new Point(point6.x / i5, point6.y / i5)));
                } else {
                    c = 1;
                    i2 = 2;
                }
                Point[] cornerPoints2 = ((Barcode) ((List) it.getResult()).get(0)).getCornerPoints();
                if (cornerPoints2 != null) {
                    Point point7 = cornerPoints2[0];
                    double d = point7.x;
                    double d2 = point7.y;
                    Point point8 = cornerPoints2[c];
                    double d3 = point8.x;
                    double d4 = point8.y;
                    this$0.getClass();
                    int i6 = i5;
                    double d5 = i2;
                    double dSqrt = Math.sqrt(Math.pow(d4 - d2, d5) + Math.pow(d3 - d, d5));
                    Point point9 = cornerPoints2[c];
                    i3 = format;
                    double d6 = point9.x;
                    double d7 = point9.y;
                    Point point10 = cornerPoints2[i2];
                    double dSqrt2 = Math.sqrt(Math.pow(((double) point10.y) - d7, d5) + Math.pow(point10.x - d6, d5));
                    str = "SFBarcode";
                    Log.v(str, "Calculate Distance - " + dSqrt + ' ' + dSqrt2);
                    if (dSqrt > dSqrt2) {
                        Point point11 = cornerPoints2[0];
                        point = new Point(point11.x / i6, point11.y / i6);
                        Point point12 = cornerPoints2[c];
                        point2 = new Point(point12.x / i6, point12.y / i6);
                    } else {
                        Point point13 = cornerPoints2[c];
                        point = new Point(point13.x / i6, point13.y / i6);
                        Point point14 = cornerPoints2[2];
                        point2 = new Point(point14.x / i6, point14.y / i6);
                    }
                    dA = a(point, point2);
                } else {
                    i3 = format;
                    str = "SFBarcode";
                    dA = 0.0d;
                }
                Log.v(str, "angle - " + dA);
                Intrinsics.checkNotNullParameter(croppedBitmap, "croppedBitmap");
                Bitmap croppedBitmap2 = Bitmap.createBitmap(croppedBitmap.getWidth() + 50, croppedBitmap.getHeight() + 50, Bitmap.Config.ARGB_8888);
                Intrinsics.checkNotNullExpressionValue(croppedBitmap2, "createBitmap(...)");
                Canvas canvas = new Canvas(croppedBitmap2);
                canvas.drawColor(-1, PorterDuff.Mode.LIGHTEN);
                Paint paint = new Paint();
                boolean z3 = c;
                paint.setAntiAlias(z3);
                paint.setFilterBitmap(z3);
                paint.setDither(z3);
                float f = 25;
                canvas.drawBitmap(croppedBitmap, f, f, paint);
                Intrinsics.checkNotNullParameter(croppedBitmap2, "croppedBitmap");
                Matrix matrix = new Matrix();
                matrix.postRotate((float) dA);
                Bitmap bitmapCreateScaledBitmap = Bitmap.createScaledBitmap(croppedBitmap2, croppedBitmap2.getWidth(), croppedBitmap2.getHeight(), true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateScaledBitmap, "createScaledBitmap(...)");
                Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmapCreateScaledBitmap, 0, 0, bitmapCreateScaledBitmap.getWidth(), bitmapCreateScaledBitmap.getHeight(), matrix, true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                if (((Barcode) ((List) it.getResult()).get(0)).getFormat() == 2) {
                    BarcodeScanner barcodeScanner = AbstractC0094l.a;
                    Log.v(str, "decodeZxing - Started");
                    new ArrayList();
                    int[] iArr = new int[bitmapCreateBitmap.getHeight() * bitmapCreateBitmap.getWidth()];
                    bitmapCreateBitmap.getPixels(iArr, 0, bitmapCreateBitmap.getWidth(), 0, 0, bitmapCreateBitmap.getWidth(), bitmapCreateBitmap.getHeight());
                    RGBLuminanceSource rGBLuminanceSource = new RGBLuminanceSource(bitmapCreateBitmap.getWidth(), bitmapCreateBitmap.getHeight(), iArr);
                    HybridBinarizer hybridBinarizer = new HybridBinarizer(rGBLuminanceSource);
                    MultiFormatReader multiFormatReader = new MultiFormatReader();
                    HashMap map = new HashMap();
                    map.put(DecodeHintType.PURE_BARCODE, Boolean.TRUE);
                    multiFormatReader.setHints(map);
                    try {
                        try {
                            com.google.zxing.Result resultDecode = multiFormatReader.decode(new BinaryBitmap(hybridBinarizer), map);
                            if (resultDecode == null) {
                                resultDecode = multiFormatReader.decode(new BinaryBitmap(new GlobalHistogramBinarizer(rGBLuminanceSource)), map);
                            }
                            multiFormatReader.reset();
                            if (resultDecode == null) {
                                LuminanceSource luminanceSourceInvert = rGBLuminanceSource.invert();
                                try {
                                    try {
                                        com.google.zxing.Result resultDecodeWithState = multiFormatReader.decodeWithState(new BinaryBitmap(new HybridBinarizer(luminanceSourceInvert)));
                                        resultDecode = resultDecodeWithState == null ? multiFormatReader.decodeWithState(new BinaryBitmap(new GlobalHistogramBinarizer(luminanceSourceInvert))) : resultDecodeWithState;
                                        Log.v("White_points_inverted", resultDecode.getResultPoints()[0].toString());
                                        multiFormatReader.reset();
                                    } catch (Exception unused) {
                                        Log.v("processModelResultZxing", "Exception - 1");
                                        multiFormatReader.reset();
                                        text = null;
                                        displayValue = text;
                                        i4 = 0;
                                        StringBuilder sb = new StringBuilder("MLOutput After- ");
                                        sb.append(((Barcode) ((List) it.getResult()).get(i4)).getDisplayValue());
                                        sb.append("  format: ");
                                        int format2 = ((Barcode) ((List) it.getResult()).get(i4)).getFormat();
                                        this$0.getClass();
                                        sb.append(a(format2));
                                        Log.v(str, sb.toString());
                                        Log.v(str, "zxingOutput After- " + displayValue);
                                        if (displayValue != null) {
                                            scanResultSuccess = new ScanResultSuccess(displayValue, a(i3), z, arrayList, result.d, result.b);
                                            Log.v(str, "decodeML - Completed");
                                            Log.v("processModelResultML", scanResultSuccess.getText());
                                            z2 = this$0.b;
                                            if (!z2) {
                                                if (z2) {
                                                    onBarcodeScanResultCallback = this$0.P;
                                                    if (onBarcodeScanResultCallback != null) {
                                                        onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                                                    }
                                                    this$0.x = new ArrayList();
                                                } else {
                                                    onBarcodeScanResultCallback = this$0.P;
                                                    if (onBarcodeScanResultCallback != null) {
                                                        onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                                                    }
                                                    this$0.x = new ArrayList();
                                                }
                                            } else if (z2) {
                                                onBarcodeScanResultCallback = this$0.P;
                                                if (onBarcodeScanResultCallback != null) {
                                                    onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                                                }
                                                this$0.x = new ArrayList();
                                            } else {
                                                onBarcodeScanResultCallback = this$0.P;
                                                if (onBarcodeScanResultCallback != null) {
                                                    onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                                                }
                                                this$0.x = new ArrayList();
                                            }
                                            beepManager = this$0.M;
                                            if (beepManager != null) {
                                                beepManager.playBeepSoundAndVibrate();
                                            }
                                            a(result, scanResultSuccess, i);
                                            ArrayList arrayList2 = new ArrayList();
                                            this$0.F = arrayList2;
                                            String text2 = scanResultSuccess.getText();
                                            Matrix previewToCropTransform = this$0.l;
                                            RectF yolov4location = result.d;
                                            Intrinsics.checkNotNullParameter(previewToCropTransform, "previewToCropTransform");
                                            Intrinsics.checkNotNullParameter(yolov4location, "yolov4location");
                                            previewToCropTransform.mapRect(yolov4location);
                                            arrayList2.add(new ArObject(text2, yolov4location, this$0.N, 0, Color.parseColor("#1ab3fb"), null, false));
                                            this$0.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda10
                                                @Override // java.lang.Runnable
                                                public final void run() {
                                                    M.g(this.f$0);
                                                }
                                            });
                                            this$0.B.add(result);
                                            this$0.b();
                                            croppedBitmap.recycle();
                                            listener.onSuccess("Scanned");
                                        }
                                    }
                                } catch (Throwable th) {
                                    multiFormatReader.reset();
                                    throw th;
                                }
                            }
                            String text3 = resultDecode.getText();
                            if (text3 != null) {
                                Log.v("processModelResultZxing", "decodeZxing - ".concat(text3));
                            }
                            Log.v(str, "decodeZxing - Completed");
                            text = resultDecode.getText();
                        } catch (Exception unused2) {
                            Log.v("processModelResultZxing", "Exception - 0");
                        }
                        displayValue = text;
                        i4 = 0;
                    } catch (Throwable th2) {
                        multiFormatReader.reset();
                        throw th2;
                    }
                } else {
                    i4 = 0;
                    displayValue = ((Barcode) ((List) it.getResult()).get(0)).getDisplayValue();
                }
                StringBuilder sb2 = new StringBuilder("MLOutput After- ");
                sb2.append(((Barcode) ((List) it.getResult()).get(i4)).getDisplayValue());
                sb2.append("  format: ");
                int format3 = ((Barcode) ((List) it.getResult()).get(i4)).getFormat();
                this$0.getClass();
                sb2.append(a(format3));
                Log.v(str, sb2.toString());
                Log.v(str, "zxingOutput After- " + displayValue);
                if (displayValue != null) {
                    scanResultSuccess = new ScanResultSuccess(displayValue, a(i3), z, arrayList, result.d, result.b);
                    Log.v(str, "decodeML - Completed");
                    Log.v("processModelResultML", scanResultSuccess.getText());
                    z2 = this$0.b;
                    if (!z2 && !this$0.d) {
                        ArrayList<ScanResultSuccess> arrayList3 = new ArrayList<>();
                        arrayList3.add(scanResultSuccess);
                        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback2 = this$0.P;
                        if (onBarcodeScanResultCallback2 != null) {
                            onBarcodeScanResultCallback2.onBatchScanResultSuccess(arrayList3);
                        }
                    } else if (z2 || !this$0.d) {
                        onBarcodeScanResultCallback = this$0.P;
                        if (onBarcodeScanResultCallback != null) {
                            onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
                        }
                        this$0.x = new ArrayList();
                    } else {
                        OneOFManyCodesScanResults oneOFManyCodesScanResults = new OneOFManyCodesScanResults(scanResultSuccess.getText(), scanResultSuccess.getBarcodeFormat().name());
                        this$0.J.add(oneOFManyCodesScanResults);
                        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback3 = this$0.P;
                        if (onBarcodeScanResultCallback3 != null) {
                            onBarcodeScanResultCallback3.onOneOfManyCodeResult(this$0.J);
                        }
                        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback4 = this$0.P;
                        if (onBarcodeScanResultCallback4 != null) {
                            onBarcodeScanResultCallback4.onOneofManyCodeSelected(oneOFManyCodesScanResults);
                        }
                    }
                    beepManager = this$0.M;
                    if (beepManager != null) {
                        beepManager.playBeepSoundAndVibrate();
                    }
                    a(result, scanResultSuccess, i);
                    ArrayList arrayList4 = new ArrayList();
                    this$0.F = arrayList4;
                    String text4 = scanResultSuccess.getText();
                    Matrix previewToCropTransform2 = this$0.l;
                    RectF yolov4location2 = result.d;
                    Intrinsics.checkNotNullParameter(previewToCropTransform2, "previewToCropTransform");
                    Intrinsics.checkNotNullParameter(yolov4location2, "yolov4location");
                    previewToCropTransform2.mapRect(yolov4location2);
                    arrayList4.add(new ArObject(text4, yolov4location2, this$0.N, 0, Color.parseColor("#1ab3fb"), null, false));
                    this$0.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda10
                        @Override // java.lang.Runnable
                        public final void run() {
                            M.g(this.f$0);
                        }
                    });
                    this$0.B.add(result);
                    this$0.b();
                    croppedBitmap.recycle();
                    listener.onSuccess("Scanned");
                }
            }
        }
    }

    public final void a(Bitmap bitmap, C0084b c0084b, D d, boolean z, int i, String str, boolean z2, Analyzer.OnAnalyzeListener onAnalyzeListener) {
        BarcodeScanner barcodeScanner = AbstractC0094l.a;
        String str2 = c0084b.b;
        RectF rectF = c0084b.d;
        new ArrayList();
        ScanResultSuccess scanResultSuccess = null;
        GrayU8 grayU8BitmapToGray = ConvertBitmap.bitmapToGray(bitmap, null, null);
        Intrinsics.checkNotNullExpressionValue(grayU8BitmapToGray, "bitmapToGray(...)");
        QrCodePreciseDetector qrCodePreciseDetectorQrcode = FactoryFiducial.qrcode(new ConfigQrCode(), GrayU8.class);
        Intrinsics.checkNotNullExpressionValue(qrCodePreciseDetectorQrcode, "qrcode(...)");
        qrCodePreciseDetectorQrcode.process(grayU8BitmapToGray);
        List detections = qrCodePreciseDetectorQrcode.getDetections();
        if (detections.size() > 0) {
            String str3 = ((QrCode) detections.get(0)).message;
            Polygon2D_F64 polygon2D_F64 = ((QrCode) detections.get(0)).bounds;
            ArrayList arrayList = new ArrayList();
            arrayList.add(new PointF((float) polygon2D_F64.get(0).x, (float) polygon2D_F64.get(0).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(1).x, (float) polygon2D_F64.get(1).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(2).x, (float) polygon2D_F64.get(2).y));
            arrayList.add(new PointF((float) polygon2D_F64.get(3).x, (float) polygon2D_F64.get(3).y));
            Intrinsics.checkNotNull(str3);
            scanResultSuccess = new ScanResultSuccess(str3, BarcodeFormat.QR_CODE, z, arrayList, rectF, str2);
        }
        if (scanResultSuccess == null) {
            ScanflowLog.INSTANCE.v("SFBarcode", "Boofcv decode failed in mode: " + d);
            a(bitmap, c0084b, z, i, str, onAnalyzeListener);
            return;
        }
        ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
        scanflowLog.v("SFBarcode", "qrResult " + scanResultSuccess.getText());
        BeepManager beepManager = this.M;
        if (beepManager != null) {
            beepManager.playBeepSoundAndVibrate();
        }
        a(c0084b, scanResultSuccess, i);
        StringBuilder sb = new StringBuilder("boundingBox = ");
        Matrix previewToCropTransform = this.l;
        RectF yolov4location = c0084b.d;
        Intrinsics.checkNotNullParameter(previewToCropTransform, "previewToCropTransform");
        Intrinsics.checkNotNullParameter(yolov4location, "yolov4location");
        previewToCropTransform.mapRect(yolov4location);
        sb.append(yolov4location);
        scanflowLog.v("SFBarcode", sb.toString());
        ArrayList arrayList2 = new ArrayList();
        this.F = arrayList2;
        arrayList2.add(new ArObject(scanResultSuccess.getText(), c0084b.d, this.N, 0, Color.parseColor("#1ab3fb"), null, false));
        this.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda11
            @Override // java.lang.Runnable
            public final void run() {
                M.h(this.f$0);
            }
        });
        this.B.add(c0084b);
        scanflowLog.v("SFBarcode", "Boofcv decode succeed in mode: " + d);
        b();
        D d2 = D.INITIAL;
        bitmap.recycle();
        ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this.P;
        if (onBarcodeScanResultCallback != null) {
            onBarcodeScanResultCallback.onScanResultSuccess(scanResultSuccess);
        }
        this.x = new ArrayList();
        onAnalyzeListener.onSuccess("Scanned");
    }

    public final void a(C0084b c0084b, LowLightResponse lowLightResponse, Analyzer.OnAnalyzeListener onAnalyzeListener) {
        ProcessResult processResult;
        Bitmap src;
        Bitmap bitmapCreateBitmap;
        int width;
        int height;
        int i;
        int[] iArr;
        int[] iArr2;
        int[] iArr3;
        int i2;
        int[] iArr4;
        int i3;
        int i4;
        List<EnhancementResult> results;
        Matrix matrix = this.k;
        if (matrix != null) {
            matrix.mapRect(c0084b.d);
        }
        Log.v("SFBarcode", "Result Location: " + c0084b + ".location");
        Bitmap orginal = a(lowLightResponse.getBitmap(), c0084b.d);
        if (orginal == null) {
            a(onAnalyzeListener);
            a();
            return;
        }
        if (c0084b.b.equals("qr_code")) {
            D d = D.INITIAL;
            D dA = a(orginal, c0084b.b);
            D d2 = D.LONG_DISTANCE;
            if (dA != d2) {
                ScanflowLog.INSTANCE.v("SFBarcode", "Is Long Distance Image : false");
                a(orginal, c0084b, d, false, 1, c0084b.b, lowLightResponse.isLowLight(), onAnalyzeListener);
                return;
            }
            ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
            scanflowLog.v("SFBarcode", "Is Long Distance Image : true");
            scanflowLog.v("SFBarcode", "Super Resolution & Gamma Correction applied - Started");
            Bitmap bitmap = AbstractC0103s.a;
            Enhancement enhancement = this.z;
            Intrinsics.checkNotNullParameter(orginal, "orginal");
            try {
                BitmapFactory.Options options = new BitmapFactory.Options();
                options.inJustDecodeBounds = true;
                Bitmap bitmapA = AbstractC0103s.a(orginal);
                int i5 = 2;
                while ((((int) (options.outWidth * 2.0f)) / i5) * (((int) (options.outHeight * 2.0f)) / i5) > 12582912) {
                    i5 *= 2;
                }
                options.inJustDecodeBounds = false;
                options.inSampleSize = i5;
                double dMax = Math.max(Math.sqrt((bitmapA.getWidth() * bitmapA.getHeight()) / 8388608), 1.0d);
                Bitmap bitmapCreateScaledBitmap = Bitmap.createScaledBitmap(bitmapA, (int) (((double) bitmapA.getWidth()) / dMax), (int) (((double) bitmapA.getHeight()) / dMax), false);
                Intrinsics.checkNotNull(enhancement);
                processResult = enhancement.process(new Bitmap[]{bitmapCreateScaledBitmap}, 0);
                while (true) {
                    iArr4 = iArr;
                    if (i2 >= i) {
                        break;
                    }
                    double d3 = ((double) i2) / 255.0d;
                    iArr4[i2] = Math.min(255, (int) ((Math.pow(d3, 1.6666666666666667d) * 255.0d) + 0.5d));
                    iArr2[i2] = Math.min(255, (int) ((Math.pow(d3, 1.6666666666666667d) * 255.0d) + 0.5d));
                    iArr3[i2] = Math.min(255, (int) ((Math.pow(d3, 1.6666666666666667d) * 255.0d) + 0.5d));
                    i2++;
                    iArr = iArr4;
                    width = width;
                    height = height;
                    i = 256;
                }
                while (true) {
                    int i6 = height;
                    if (i4 >= i3) {
                        scanflowLog.v("SFBarcode", "Super Resolution & Gamma Correction applied");
                        src.recycle();
                        a(bitmapCreateBitmap, c0084b, d2, true, 2, c0084b.b, lowLightResponse.isLowLight(), onAnalyzeListener);
                        return;
                    }
                    height = i6;
                    int i7 = 0;
                    while (i7 < height) {
                        int pixel = src.getPixel(i4, i7);
                        bitmapCreateBitmap.setPixel(i4, i7, Color.argb(Color.alpha(pixel), iArr4[Color.red(pixel)], iArr2[Color.green(pixel)], iArr3[Color.blue(pixel)]));
                        i7++;
                        src = src;
                    }
                    i4++;
                }
            } catch (OutOfMemoryError e) {
                e.printStackTrace();
                processResult = new ProcessResult(new ArrayList(), new String[0], 0L, 0L);
            }
            Intrinsics.checkNotNull(enhancement);
            enhancement.process(new Bitmap[]{AbstractC0103s.a}, 0);
            Intrinsics.checkNotNull(processResult);
            EnhancementResult enhancementResult = (processResult == null || (results = processResult.getResults()) == null) ? null : results.get(0);
            Intrinsics.checkNotNull(enhancementResult);
            src = enhancementResult.getEnhancedImages()[0];
            Intrinsics.checkNotNull(src);
            Intrinsics.checkNotNullParameter(src, "src");
            int width2 = src.getWidth();
            int height2 = src.getHeight();
            Bitmap.Config config = src.getConfig();
            if (config == null) {
                config = Bitmap.Config.ARGB_8888;
            }
            bitmapCreateBitmap = Bitmap.createBitmap(width2, height2, config);
            Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
            width = src.getWidth();
            height = src.getHeight();
            i = 256;
            iArr = new int[256];
            iArr2 = new int[256];
            iArr3 = new int[256];
            i2 = 0;
            i3 = width;
            i4 = 0;
        } else {
            D d4 = D.INITIAL;
            if (a(orginal, c0084b.b) != D.LONG_DISTANCE) {
                String str = c0084b.b;
                lowLightResponse.isLowLight();
                a(orginal, c0084b, false, 1, str, onAnalyzeListener);
            } else {
                Bitmap bitmapA2 = AbstractC0103s.a(orginal);
                String str2 = c0084b.b;
                lowLightResponse.isLowLight();
                a(bitmapA2, c0084b, true, 1, str2, onAnalyzeListener);
            }
        }
    }

    public final void a() {
        if (System.currentTimeMillis() - this.H > this.I) {
            this.E.post(new Runnable() { // from class: com.scanflow.datacapture.barinternal.M$$ExternalSyntheticLambda7
                @Override // java.lang.Runnable
                public final void run() {
                    M.i(this.f$0);
                }
            });
        }
    }

    public final void a(Analyzer.OnAnalyzeListener onAnalyzeListener) {
        if (this.q) {
            ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = this.P;
            if (onBarcodeScanResultCallback != null) {
                onBarcodeScanResultCallback.onScanResultFailure("Scan Failed!");
            }
            onAnalyzeListener.onPerformCaptureScan();
        }
        onAnalyzeListener.onFailure();
    }

    public final synchronized void a(SFCameraView sFCameraView) {
        this.s = sFCameraView.getPreviewView().getMeasuredWidth();
        this.t = sFCameraView.getPreviewView().getMeasuredHeight();
        ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
        StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
        String str = String.format("PreviewMetrics: %dx%d", Arrays.copyOf(new Object[]{Integer.valueOf(this.s), Integer.valueOf(this.t)}, 2));
        Intrinsics.checkNotNullExpressionValue(str, "format(...)");
        scanflowLog.i("SFBarcode", str);
    }

    public final void a(DecodeConfig decodeConfig) {
        Intrinsics.checkNotNullParameter(decodeConfig, "decodeConfig");
        switch (E.a[decodeConfig.ordinal()]) {
            case 1:
                this.a = "qr_code";
                this.b = false;
                return;
            case 2:
                this.a = "bar_code";
                this.b = false;
                return;
            case 3:
                this.a = "any";
                this.b = false;
                return;
            case 4:
                this.a = "any";
                this.b = true;
                this.d = false;
                return;
            case 5:
                this.a = "any";
                this.b = true;
                this.d = true;
                return;
            case 6:
                this.a = "any";
                this.b = false;
                this.c = true;
                return;
            case 7:
                this.a = "dotmatrix_white";
                this.b = false;
                return;
            case 8:
                this.a = "dotmatrix_metal";
                this.b = false;
                return;
            default:
                throw new NoWhenBranchMatchedException();
        }
    }
}
