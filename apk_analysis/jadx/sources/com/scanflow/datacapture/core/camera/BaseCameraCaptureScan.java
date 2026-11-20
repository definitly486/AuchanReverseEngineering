package com.scanflow.datacapture.core.camera;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.Application;
import android.content.ContentValues;
import android.content.SharedPreferences;
import android.content.res.Resources;
import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.net.ConnectivityManager;
import android.net.Network;
import android.net.NetworkCapabilities;
import android.net.NetworkRequest;
import android.os.Build;
import android.provider.MediaStore;
import android.util.DisplayMetrics;
import android.util.Log;
import android.util.Range;
import android.util.Size;
import android.view.GestureDetector;
import android.view.MotionEvent;
import android.view.ScaleGestureDetector;
import android.view.View;
import android.widget.Toast;
import androidx.camera.core.Camera;
import androidx.camera.core.CameraControl;
import androidx.camera.core.CameraInfo;
import androidx.camera.core.CameraSelector;
import androidx.camera.core.ExposureState;
import androidx.camera.core.FocusMeteringAction;
import androidx.camera.core.ImageAnalysis;
import androidx.camera.core.ImageCapture;
import androidx.camera.core.ImageCaptureException;
import androidx.camera.core.ImageProxy;
import androidx.camera.core.MeteringPoint;
import androidx.camera.core.Preview;
import androidx.camera.core.UseCaseGroup;
import androidx.camera.core.ViewPort;
import androidx.camera.core.ZoomState;
import androidx.camera.view.PreviewView;
import androidx.core.content.ContextCompat;
import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleOwner;
import androidx.lifecycle.LifecycleRegistry;
import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;
import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;
import com.google.android.material.slider.Slider;
import com.google.common.util.concurrent.ListenableFuture;
import com.google.gson.Gson;
import com.scanflow.datacapture.R;
import com.scanflow.datacapture.barinternal.androidx.camera.lifecycle.ProcessCameraProvider;
import com.scanflow.datacapture.barinternal.j.d;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.ranges.RangesKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.BuildersKt__Builders_commonKt;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.Dispatchers;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.GlobalScope;
import com.scanflow.datacapture.config.VinNumberColorConfig;
import com.scanflow.datacapture.core.camera.BaseCameraCaptureScan;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.model.DeviceInfo;
import com.scanflow.datacapture.model.subscription.Result;
import com.scanflow.datacapture.model.subscription.SubscriptionResponse;
import com.scanflow.datacapture.sfbarcode.SFCameraView;
import com.scanflow.datacapture.utils.ErrorMessageUtils;
import com.scanflow.datacapture.utils.ScanflowLog;
import com.scanflow.datacapture.utils.StorageUtils;
import java.nio.charset.Charset;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.security.SecureRandom;
import java.security.spec.InvalidKeySpecException;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Arrays;
import java.util.Base64;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.TimeZone;
import java.util.UUID;
import java.util.concurrent.ExecutorService;
import java.util.concurrent.Executors;
import java.util.concurrent.TimeUnit;
import javax.crypto.BadPaddingException;
import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SecretKeyFactory;
import javax.crypto.spec.GCMParameterSpec;
import javax.crypto.spec.PBEKeySpec;
import javax.crypto.spec.SecretKeySpec;
import kotlin.coroutines.AbstractCoroutineContextElement;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.CoroutineContext;
import kotlin.coroutines.jvm.internal.DebugMetadata;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function1;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;
import kotlin.jvm.internal.StringCompanionObject;
import kotlinx.coroutines.CoroutineScope;
import okhttp3.OkHttpClient;
import okhttp3.logging.HttpLoggingInterceptor;
import org.tensorflow.lite.schema.BuiltinOperator;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

/* JADX INFO: loaded from: classes3.dex */
public final class BaseCameraCaptureScan<T> extends ScanflowReader implements com.scanflow.datacapture.barinternal.e.a.InterfaceC0036a, LifecycleOwner {
    public static final /* synthetic */ int E0 = 0;
    public com.scanflow.datacapture.barinternal.e.a A;
    public UseCaseGroup A0;
    public BeepManager B;
    public VinNumberColorConfig B0;
    public boolean C;
    public final f C0;
    public boolean D;
    public final e D0;
    public boolean E;
    public final float F;
    public boolean G;
    public boolean H;
    public long I;
    public boolean J;
    public float K;
    public float L;
    public float M;
    public float N;
    public Integer O;
    public final ExecutorService P;
    public SharedPreferences Q;
    public String R;
    public boolean S;
    public com.scanflow.datacapture.barinternal.j.c T;
    public SharedPreferences U;
    public com.scanflow.datacapture.barinternal.h.b V;
    public boolean W;
    public final String X;
    public final String Y;
    public final String Z;
    public final Activity a;
    public final String a0;
    public final Activity b;
    public final String b0;
    public final BaseCameraCaptureScan c;
    public final String c0;
    public Size d;
    public final String d0;
    public Size e;
    public final String e0;
    public final PreviewView f;
    public boolean f0;
    public ListenableFuture<ProcessCameraProvider> g;
    public boolean g0;
    public Camera h;
    public boolean h0;
    public com.scanflow.datacapture.barinternal.d.a i;
    public boolean i0;
    public ImageCapture j;
    public LocationManager j0;
    public Size k;
    public double k0;
    public ViewPort l;
    public double l0;
    public View m;
    public final String m0;
    public Slider n;
    public final AbstractCoroutineContextElement n0;
    public ScanflowReader.OnOneTouchCallback o;
    public final Analyzer<T> o0;
    public ScanflowReader.OnTextScanResultCallback p;
    public final boolean p0;
    public MutableLiveData<T> q;
    public boolean q0;
    public ScanflowReader.OnBarcodeScanResultCallback r;
    public volatile boolean r0;
    public ScanflowReader.OnIDCardScanResultCallback s;
    public MasterKey s0;
    public ScanflowReader.OnTextComponentScanResultCallback t;
    public SharedPreferences t0;
    public ScanflowReader.OnTextComponentVinPlateScanResultCallback u;
    public boolean u0;
    public ScanflowReader.OnTextComponentVinStickerScanResultCallback v;
    public boolean v0;
    public Object w;
    public boolean w0;
    public ScanflowReader.OnLicenseValidationCallback x;
    public int x0;
    public d y;
    public String y0;
    public BeepManager z;
    public final LifecycleRegistry z0;

    public static final class a implements ImageCapture.OnImageSavedCallback {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;

        public a(BaseCameraCaptureScan<T> baseCameraCaptureScan) {
            this.a = baseCameraCaptureScan;
        }

        @Override // androidx.camera.core.ImageCapture.OnImageSavedCallback
        public final void onError(ImageCaptureException exc) {
            Intrinsics.checkNotNullParameter(exc, "exc");
        }

        @Override // androidx.camera.core.ImageCapture.OnImageSavedCallback
        public final void onImageSaved(ImageCapture.OutputFileResults output) {
            Intrinsics.checkNotNullParameter(output, "output");
            String str = "Photo capture succeeded: " + output.getSavedUri();
            Activity activity = this.a.b;
            if (activity == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mActivity");
                activity = null;
            }
            Toast.makeText(activity, str, 0).show();
        }
    }

    public static final class b implements Callback<SubscriptionResponse> {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;
        public final /* synthetic */ DeviceInfo b;
        public final /* synthetic */ String c;

        @DebugMetadata(c = "com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$checkLicenseValidation$1$onResponse$1", f = "BaseCameraCaptureScan.kt", l = {}, m = "invokeSuspend")
        public static final class a extends SuspendLambda implements Function2<CoroutineScope, Continuation<? super Unit>, Object> {
            public /* synthetic */ Object a;
            public final /* synthetic */ Response<SubscriptionResponse> b;
            public final /* synthetic */ DeviceInfo c;
            public final /* synthetic */ String d;
            public final /* synthetic */ BaseCameraCaptureScan<T> e;

            /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
            public a(Response<SubscriptionResponse> response, DeviceInfo deviceInfo, String str, BaseCameraCaptureScan<T> baseCameraCaptureScan, Continuation<? super a> continuation) {
                super(2, continuation);
                this.b = response;
                this.c = deviceInfo;
                this.d = str;
                this.e = baseCameraCaptureScan;
            }

            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
            public final Continuation<Unit> create(Object obj, Continuation<?> continuation) {
                a aVar = new a(this.b, this.c, this.d, this.e, continuation);
                aVar.a = obj;
                return aVar;
            }

            @Override // kotlin.jvm.functions.Function2
            public final Object invoke(CoroutineScope coroutineScope, Continuation<? super Unit> continuation) {
                return ((a) create(coroutineScope, continuation)).invokeSuspend(Unit.INSTANCE);
            }

            @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
            public final Object invokeSuspend(Object obj) throws Throwable {
                IntrinsicsKt.getCOROUTINE_SUSPENDED();
                ResultKt.throwOnFailure(obj);
                SubscriptionResponse subscriptionResponseBody = this.b.body();
                if (subscriptionResponseBody != null) {
                    DeviceInfo deviceInfo = this.c;
                    String str = this.d;
                    BaseCameraCaptureScan<T> baseCameraCaptureScan = this.e;
                    subscriptionResponseBody.setDeviceInfo(deviceInfo);
                    subscriptionResponseBody.setApikey(str);
                    int i = BaseCameraCaptureScan.E0;
                    baseCameraCaptureScan.a(subscriptionResponseBody);
                    if (StringsKt.equals(subscriptionResponseBody.getStatus(), "Success", true)) {
                        ScanflowReader.OnLicenseValidationCallback onLicenseValidationCallback = baseCameraCaptureScan.x;
                        if (onLicenseValidationCallback != null) {
                            onLicenseValidationCallback.onLicenseSuccess(subscriptionResponseBody.getMessage());
                        }
                    } else {
                        ScanflowReader.OnLicenseValidationCallback onLicenseValidationCallback2 = baseCameraCaptureScan.x;
                        if (onLicenseValidationCallback2 != null) {
                            onLicenseValidationCallback2.onLicenseFailure(subscriptionResponseBody.getMessage());
                        }
                    }
                } else {
                    BaseCameraCaptureScan<T> baseCameraCaptureScan2 = this.e;
                    int i2 = BaseCameraCaptureScan.E0;
                    baseCameraCaptureScan2.a();
                }
                return Unit.INSTANCE;
            }
        }

        public b(BaseCameraCaptureScan<T> baseCameraCaptureScan, DeviceInfo deviceInfo, String str) {
            this.a = baseCameraCaptureScan;
            this.b = deviceInfo;
            this.c = str;
        }

        @Override // retrofit2.Callback
        public final void onFailure(Call<SubscriptionResponse> call, Throwable t) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
            Intrinsics.checkNotNullParameter(call, "call");
            Intrinsics.checkNotNullParameter(t, "t");
            BaseCameraCaptureScan<T> baseCameraCaptureScan = this.a;
            baseCameraCaptureScan.q0 = false;
            baseCameraCaptureScan.a();
        }

        @Override // retrofit2.Callback
        public final void onResponse(Call<SubscriptionResponse> call, Response<SubscriptionResponse> response) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
            Intrinsics.checkNotNullParameter(call, "call");
            Intrinsics.checkNotNullParameter(response, "response");
            this.a.q0 = false;
            if (response.code() == 200) {
                BuildersKt__Builders_commonKt.launch$default(GlobalScope.INSTANCE, Dispatchers.getIO().plus(this.a.n0), null, new a(response, this.b, this.c, this.a, null), 2, null);
            } else {
                this.a.a();
            }
        }
    }

    public static final class c implements View.OnLayoutChangeListener {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;

        public c(BaseCameraCaptureScan<T> baseCameraCaptureScan) {
            this.a = baseCameraCaptureScan;
        }

        @Override // android.view.View.OnLayoutChangeListener
        public final void onLayoutChange(View view, int i, int i2, int i3, int i4, int i5, int i6, int i7, int i8) {
            Intrinsics.checkNotNullParameter(view, "view");
            BaseCameraCaptureScan<T> baseCameraCaptureScan = this.a;
            if (view.getWidth() <= 0 || view.getHeight() <= 0) {
                return;
            }
            baseCameraCaptureScan.f();
            view.removeOnLayoutChangeListener(this);
        }
    }

    public static final class d implements Analyzer.OnAnalyzeListener {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;

        public d(BaseCameraCaptureScan<T> baseCameraCaptureScan) {
            this.a = baseCameraCaptureScan;
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void OnOneTouchCallbackCompleted() {
            ScanflowReader.OnOneTouchCallback onOneTouchCallback = this.a.o;
            if (onOneTouchCallback != null) {
                onOneTouchCallback.onCompleted();
            }
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void OnOneTouchCallbackDisable() {
            BaseCameraCaptureScan<T> baseCameraCaptureScan = this.a;
            int i = BaseCameraCaptureScan.E0;
            baseCameraCaptureScan.getClass();
            this.a.S = false;
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void OnOneTouchCallbackStarted() {
            ScanflowReader.OnOneTouchCallback onOneTouchCallback = this.a.o;
            if (onOneTouchCallback != null) {
                onOneTouchCallback.onStarted();
            }
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void onFailure() {
            MutableLiveData<T> mutableLiveData = this.a.q;
            if (mutableLiveData != null) {
                mutableLiveData.postValue(null);
            }
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void onLicenseFailed(String message) {
            Intrinsics.checkNotNullParameter(message, "message");
            MutableLiveData<T> mutableLiveData = this.a.q;
            if (mutableLiveData != null) {
                mutableLiveData.postValue(message);
            }
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void onPerformCaptureScan() {
            this.a.H = false;
        }

        @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer.OnAnalyzeListener
        public final void onSuccess(String message) {
            Intrinsics.checkNotNullParameter(message, "message");
            MutableLiveData<T> mutableLiveData = this.a.q;
            if (mutableLiveData != null) {
                mutableLiveData.postValue(message);
            }
            this.a.H = false;
        }
    }

    public static final class e extends GestureDetector.SimpleOnGestureListener {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;

        public e(BaseCameraCaptureScan<T> baseCameraCaptureScan) {
            this.a = baseCameraCaptureScan;
        }

        @Override // android.view.GestureDetector.SimpleOnGestureListener, android.view.GestureDetector.OnDoubleTapListener
        public final boolean onDoubleTap(MotionEvent e) {
            CameraControl cameraControl;
            CameraControl cameraControl2;
            CameraInfo cameraInfo;
            LiveData<ZoomState> zoomState;
            ZoomState value;
            CameraInfo cameraInfo2;
            LiveData<ZoomState> zoomState2;
            ZoomState value2;
            CameraInfo cameraInfo3;
            LiveData<ZoomState> zoomState3;
            ZoomState value3;
            Intrinsics.checkNotNullParameter(e, "e");
            ScanflowLog.INSTANCE.e("XXX onGesture", "onDoubleTap");
            Camera camera = this.a.h;
            Float fValueOf = null;
            Float fValueOf2 = (camera == null || (cameraInfo3 = camera.getCameraInfo()) == null || (zoomState3 = cameraInfo3.getZoomState()) == null || (value3 = zoomState3.getValue()) == null) ? null : Float.valueOf(value3.getZoomRatio());
            Camera camera2 = this.a.h;
            Float fValueOf3 = (camera2 == null || (cameraInfo2 = camera2.getCameraInfo()) == null || (zoomState2 = cameraInfo2.getZoomState()) == null || (value2 = zoomState2.getValue()) == null) ? null : Float.valueOf(value2.getMinZoomRatio());
            Camera camera3 = this.a.h;
            if (camera3 != null && (cameraInfo = camera3.getCameraInfo()) != null && (zoomState = cameraInfo.getZoomState()) != null && (value = zoomState.getValue()) != null) {
                fValueOf = Float.valueOf(value.getMaxZoomRatio());
            }
            if (fValueOf2 != null && fValueOf != null && fValueOf3 != null) {
                if (fValueOf2.floatValue() > fValueOf3.floatValue() || Intrinsics.areEqual(fValueOf2, fValueOf)) {
                    Camera camera4 = this.a.h;
                    if (camera4 != null && (cameraControl = camera4.getCameraControl()) != null) {
                        cameraControl.setZoomRatio(fValueOf3.floatValue());
                    }
                } else {
                    Camera camera5 = this.a.h;
                    if (camera5 != null && (cameraControl2 = camera5.getCameraControl()) != null) {
                        cameraControl2.setZoomRatio(fValueOf.floatValue());
                    }
                }
            }
            return super.onDoubleTap(e);
        }
    }

    public static final class f extends ScaleGestureDetector.SimpleOnScaleGestureListener {
        public final /* synthetic */ BaseCameraCaptureScan<T> a;

        public f(BaseCameraCaptureScan<T> baseCameraCaptureScan) {
            this.a = baseCameraCaptureScan;
        }

        @Override // android.view.ScaleGestureDetector.SimpleOnScaleGestureListener, android.view.ScaleGestureDetector.OnScaleGestureListener
        public final boolean onScale(ScaleGestureDetector detector) {
            CameraInfo cameraInfo;
            LiveData<ZoomState> zoomState;
            ZoomState value;
            Intrinsics.checkNotNullParameter(detector, "detector");
            float scaleFactor = detector.getScaleFactor();
            Camera camera = this.a.h;
            Float fValueOf = (camera == null || (cameraInfo = camera.getCameraInfo()) == null || (zoomState = cameraInfo.getZoomState()) == null || (value = zoomState.getValue()) == null) ? null : Float.valueOf(value.getZoomRatio());
            if (fValueOf == null) {
                return true;
            }
            this.a.zoomTo(fValueOf.floatValue() * scaleFactor);
            return true;
        }
    }

    public static final class g extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public g(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class h extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public h(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class i extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public i(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class j extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public j(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class k extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public k(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class l extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public l(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class m extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public m(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public static final class n extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public n(CoroutineExceptionHandler.Key key) {
            super(key);
        }

        @Override // com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler
        public final void handleException(CoroutineContext coroutineContext, Throwable th) {
            String message = th.getMessage();
            if (message != null) {
                Log.d("Error", message);
            }
        }
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new n(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "Session Init");
        this.m0 = "License_Verification";
        this.c = this;
        this.a = activity;
        this.b = activity;
        if (activity == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity = null;
        }
        this.f = new PreviewView(activity);
        this.X = SCANFLOW_LICENSE_KEY;
        c();
    }

    public static final void d(Function1 function1, Object obj) {
        function1.invoke(obj);
    }

    public final void a(String str) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
        this.q0 = true;
        if (str.length() == 0 || StringsKt.contains$default((CharSequence) str, (CharSequence) "SCANFLOW LICENSE", false, 2, (Object) null)) {
            ScanflowReader.OnLicenseValidationCallback onLicenseValidationCallback = this.x;
            if (onLicenseValidationCallback != null) {
                onLicenseValidationCallback.onLicenseFailure(ErrorMessageUtils.Error_12);
            }
            a(new SubscriptionResponse(ErrorMessageUtils.Error_12, null, "Error", null, str));
            return;
        }
        a(new SubscriptionResponse(ErrorMessageUtils.Error_0, null, "Error", null, str));
        Activity activity = this.b;
        if (activity == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity = null;
        }
        DeviceInfo deviceInfoA = com.scanflow.datacapture.barinternal.e.b.a(activity, this.m0);
        HashMap<String, String> map = new HashMap<>();
        map.put("platform", "Android");
        map.put("deviceMake", deviceInfoA.getDeviceMake());
        map.put("deviceModel", deviceInfoA.getDeviceModel());
        map.put("osVersion", deviceInfoA.getOsVersion());
        map.put("bundleId", deviceInfoA.getBundleId());
        map.put("deviceUId", deviceInfoA.getDeviceId());
        map.put("productType", deviceInfoA.getProductType());
        Intrinsics.checkNotNullParameter("https://scanflowprod.azurewebsites.net/", "apiUrl");
        HttpLoggingInterceptor httpLoggingInterceptor = new HttpLoggingInterceptor(null, 1, null);
        httpLoggingInterceptor.setLevel(HttpLoggingInterceptor.Level.NONE);
        OkHttpClient.Builder builder = new OkHttpClient.Builder();
        TimeUnit timeUnit = TimeUnit.SECONDS;
        com.scanflow.datacapture.barinternal.g.a aVar = (com.scanflow.datacapture.barinternal.g.a) new Retrofit.Builder().baseUrl("https://scanflowprod.azurewebsites.net/").client(builder.connectTimeout(60L, timeUnit).writeTimeout(60L, timeUnit).readTimeout(60L, timeUnit).addInterceptor(httpLoggingInterceptor).build()).addConverterFactory(GsonConverterFactory.create()).build().create(com.scanflow.datacapture.barinternal.g.a.class);
        Intrinsics.checkNotNull(aVar);
        aVar.a(str, map).enqueue(new b(this, deviceInfoA, str));
    }

    /* JADX WARN: Code duplicated, block: B:54:0x0191  */
    public final void b(String SCANFLOW_LICENSE_KEY) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, ParseException, InvalidAlgorithmParameterException {
        StringBuilder sb;
        String str;
        Date date;
        String lastSyncDate;
        String subscriptionEndDate;
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        SharedPreferences sharedPreferences = this.t0;
        Date date2 = null;
        if (sharedPreferences == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences = null;
        }
        String strValueOf = String.valueOf(sharedPreferences.getString(this.Y + SCANFLOW_LICENSE_KEY, ""));
        if (!this.W) {
            if (strValueOf.length() != 0) {
                a();
                return;
            }
            ScanflowReader.OnLicenseValidationCallback onLicenseValidationCallback = this.x;
            if (onLicenseValidationCallback != null) {
                onLicenseValidationCallback.onLicenseFailure(ErrorMessageUtils.Error_19);
            }
            a(new SubscriptionResponse(ErrorMessageUtils.Error_19, null, "Error", null, SCANFLOW_LICENSE_KEY));
            return;
        }
        if (strValueOf.length() > 0) {
            try {
                byte[] bArrDecode = Base64.getDecoder().decode(strValueOf);
                Intrinsics.checkNotNull(bArrDecode);
                byte[] bArrCopyOfRange = ArraysKt.copyOfRange(bArrDecode, 0, 12);
                byte[] bArrCopyOfRange2 = ArraysKt.copyOfRange(bArrDecode, 12, bArrDecode.length);
                GCMParameterSpec gCMParameterSpec = new GCMParameterSpec(128, bArrCopyOfRange);
                SecretKeyFactory secretKeyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256");
                SharedPreferences sharedPreferences2 = this.t0;
                if (sharedPreferences2 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                    sharedPreferences2 = null;
                }
                char[] charArray = String.valueOf(sharedPreferences2.getString(this.Z, "")).toCharArray();
                Intrinsics.checkNotNullExpressionValue(charArray, "toCharArray(...)");
                SharedPreferences sharedPreferences3 = this.t0;
                if (sharedPreferences3 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                    sharedPreferences3 = null;
                }
                String strValueOf2 = String.valueOf(sharedPreferences3.getString(this.a0, ""));
                Charset charset = Charsets.UTF_8;
                byte[] bytes = strValueOf2.getBytes(charset);
                Intrinsics.checkNotNullExpressionValue(bytes, "getBytes(...)");
                SecretKeySpec secretKeySpec = new SecretKeySpec(secretKeyFactory.generateSecret(new PBEKeySpec(charArray, bytes, 65536, 256)).getEncoded(), "AES");
                Cipher cipher = Cipher.getInstance("AES/GCM/NoPadding");
                cipher.init(2, secretKeySpec, gCMParameterSpec);
                byte[] bArrDoFinal = cipher.doFinal(bArrCopyOfRange2);
                Intrinsics.checkNotNullExpressionValue(bArrDoFinal, "doFinal(...)");
                str = new String(bArrDoFinal, charset);
            } catch (InvalidAlgorithmParameterException e2) {
                e = e2;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (InvalidKeyException e3) {
                e = e3;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (NoSuchAlgorithmException e4) {
                e = e4;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (InvalidKeySpecException e5) {
                e = e5;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (BadPaddingException e6) {
                e = e6;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (IllegalBlockSizeException e7) {
                e = e7;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            } catch (NoSuchPaddingException e8) {
                e = e8;
                sb = new StringBuilder("Error occured during decryption: ");
                sb.append(e);
                System.out.println((Object) sb.toString());
                str = null;
            }
            Object objFromJson = new Gson().fromJson(str, (Class<Object>) SubscriptionResponse.class);
            Intrinsics.checkNotNullExpressionValue(objFromJson, "fromJson(...)");
            SubscriptionResponse subscriptionResponse = (SubscriptionResponse) objFromJson;
            Result result = subscriptionResponse.getResult();
            if (result != null && result.getAnalyticsId() != null && subscriptionResponse.getResult() != null) {
                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
                Result result2 = subscriptionResponse.getResult();
                if (result2 == null || (subscriptionEndDate = result2.getSubscriptionEndDate()) == null) {
                    date = null;
                } else {
                    TimeZone timeZone = TimeZone.getTimeZone("UTC");
                    Intrinsics.checkNotNullParameter(subscriptionEndDate, "<this>");
                    Intrinsics.checkNotNullParameter("yyyy-MM-dd'T'HH:mm:ss.SSS", "dateFormat");
                    Intrinsics.checkNotNullParameter(timeZone, "timeZone");
                    SimpleDateFormat simpleDateFormat2 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS", Locale.getDefault());
                    simpleDateFormat2.setTimeZone(timeZone);
                    Date date3 = simpleDateFormat2.parse(subscriptionEndDate);
                    if (date3 != null) {
                        TimeZone timeZone2 = TimeZone.getDefault();
                        Intrinsics.checkNotNullParameter(date3, "<this>");
                        Intrinsics.checkNotNullParameter("yyyy-MM-dd'T'HH:mm:ss.SSS", "dateFormat");
                        Intrinsics.checkNotNullParameter(timeZone2, "timeZone");
                        SimpleDateFormat simpleDateFormat3 = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS", Locale.getDefault());
                        simpleDateFormat3.setTimeZone(timeZone2);
                        String str2 = simpleDateFormat3.format(date3);
                        if (str2 != null) {
                            date = simpleDateFormat.parse(str2);
                        } else {
                            date = null;
                        }
                    } else {
                        date = null;
                    }
                }
                Date date4 = new Date(System.currentTimeMillis());
                if (date4.after(date)) {
                    Result result3 = subscriptionResponse.getResult();
                    if (result3 != null && (lastSyncDate = result3.getLastSyncDate()) != null) {
                        date2 = simpleDateFormat.parse(lastSyncDate);
                    }
                    if (date2 == null || !date2.before(date4)) {
                        return;
                    }
                    a(this.X);
                    return;
                }
                return;
            }
        }
        a(SCANFLOW_LICENSE_KEY);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader bindFlashlightView(View view) {
        this.m = view;
        com.scanflow.datacapture.barinternal.e.a aVar = this.A;
        if (aVar != null) {
            aVar.d = view != null;
        }
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader bindSliderView(Slider slider) {
        this.n = slider;
        return this;
    }

    public final void c() {
        Size size;
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "initData()");
        try {
            StorageUtils storageUtils = StorageUtils.INSTANCE;
            Activity activity = this.a;
            if (activity == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mContext");
                activity = null;
            }
            storageUtils.deleteDirectory(activity, "Scanflow");
            a(this.O);
        } catch (Exception unused) {
        }
        Activity activity2 = this.b;
        if (activity2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity2 = null;
        }
        this.s0 = new MasterKey.Builder(activity2, "_androidx_security_master_key_").setKeyScheme(MasterKey.KeyScheme.AES256_GCM).build();
        Activity activity3 = this.a;
        if (activity3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity3 = null;
        }
        String str = this.X;
        MasterKey masterKey = this.s0;
        if (masterKey == null) {
            Intrinsics.throwUninitializedPropertyAccessException("masterKey");
            masterKey = null;
        }
        SharedPreferences sharedPreferencesCreate = EncryptedSharedPreferences.create(activity3, str, masterKey, EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV, EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM);
        this.t0 = sharedPreferencesCreate;
        if (sharedPreferencesCreate == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferencesCreate = null;
        }
        SharedPreferences.Editor editorEdit = sharedPreferencesCreate.edit();
        editorEdit.putString(this.Z, this.c0);
        editorEdit.putString(this.a0, this.d0);
        editorEdit.putString(this.b0, this.e0);
        editorEdit.apply();
        MutableLiveData<T> mutableLiveData = new MutableLiveData<>();
        this.q = mutableLiveData;
        BaseCameraCaptureScan baseCameraCaptureScan = this.c;
        if (baseCameraCaptureScan == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
            baseCameraCaptureScan = null;
        }
        mutableLiveData.observe(baseCameraCaptureScan, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda1
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                BaseCameraCaptureScan.a(this.f$0, obj);
            }
        });
        this.y = new d(this);
        Activity activity4 = this.a;
        if (activity4 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity4 = null;
        }
        this.T = new com.scanflow.datacapture.barinternal.j.c(activity4);
        Activity activity5 = this.b;
        if (activity5 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity5 = null;
        }
        this.Q = activity5.getSharedPreferences("Scanflow_pref", 0);
        Activity activity6 = this.b;
        if (activity6 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity6 = null;
        }
        SharedPreferences sharedPreferences = activity6.getSharedPreferences("scanflow_datastore", 0);
        Intrinsics.checkNotNullParameter(sharedPreferences, "<set-?>");
        this.U = sharedPreferences;
        Activity activity7 = this.a;
        if (activity7 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity7 = null;
        }
        BeepManager beepManager = new BeepManager(activity7, Integer.valueOf(R.raw.oneofmany_beep));
        this.B = beepManager;
        beepManager.setVibrate(false);
        BeepManager beepManager2 = this.B;
        if (beepManager2 != null) {
            beepManager2.setPlayBeep(true);
        }
        Activity activity8 = this.b;
        if (activity8 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity8 = null;
        }
        Application application = activity8.getApplication();
        Intrinsics.checkNotNullExpressionValue(application, "getApplication(...)");
        com.scanflow.datacapture.barinternal.h.b bVar = (com.scanflow.datacapture.barinternal.h.b) new ViewModelProvider.AndroidViewModelFactory(application).create(com.scanflow.datacapture.barinternal.h.b.class);
        this.V = bVar;
        if (bVar == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPreferenceViewModel");
            bVar = null;
        }
        SharedPreferences sharedPreferences2 = this.U;
        if (sharedPreferences2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPref");
            sharedPreferences2 = null;
        }
        bVar.getClass();
        Intrinsics.checkNotNullParameter(sharedPreferences2, "sharedPreferences");
        Intrinsics.checkNotNullParameter(sharedPreferences2, "<set-?>");
        com.scanflow.datacapture.barinternal.h.a aVarA = com.scanflow.datacapture.barinternal.h.d.a(sharedPreferences2, com.scanflow.datacapture.barinternal.h.c.a);
        Intrinsics.checkNotNullParameter(aVarA, "<set-?>");
        bVar.a = aVarA;
        com.scanflow.datacapture.barinternal.h.a aVarA2 = com.scanflow.datacapture.barinternal.h.d.a(sharedPreferences2, com.scanflow.datacapture.barinternal.h.c.b);
        Intrinsics.checkNotNullParameter(aVarA2, "<set-?>");
        bVar.b = aVarA2;
        com.scanflow.datacapture.barinternal.h.a aVarA3 = com.scanflow.datacapture.barinternal.h.d.a(sharedPreferences2, com.scanflow.datacapture.barinternal.h.c.c);
        Intrinsics.checkNotNullParameter(aVarA3, "<set-?>");
        bVar.c = aVarA3;
        com.scanflow.datacapture.barinternal.h.a aVarA4 = com.scanflow.datacapture.barinternal.h.d.a(sharedPreferences2, com.scanflow.datacapture.barinternal.h.c.d);
        Intrinsics.checkNotNullParameter(aVarA4, "<set-?>");
        bVar.d = aVarA4;
        Activity activity9 = this.b;
        if (activity9 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity9 = null;
        }
        StringsKt.equals$default(activity9.getPackageName(), "com.usec.containermanagement", false, 2, null);
        com.scanflow.datacapture.barinternal.h.b bVar2 = this.V;
        if (bVar2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPreferenceViewModel");
            bVar2 = null;
        }
        com.scanflow.datacapture.barinternal.h.a aVar = bVar2.a;
        if (aVar == null) {
            Intrinsics.throwUninitializedPropertyAccessException("DS_EXP_DATE");
            aVar = null;
        }
        BaseCameraCaptureScan baseCameraCaptureScan2 = this.c;
        if (baseCameraCaptureScan2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
            baseCameraCaptureScan2 = null;
        }
        final Function1 function1 = new Function1() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda2
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return BaseCameraCaptureScan.a(this.f$0, (String) obj);
            }
        };
        aVar.observe(baseCameraCaptureScan2, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda3
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                BaseCameraCaptureScan.b(function1, obj);
            }
        });
        com.scanflow.datacapture.barinternal.h.b bVar3 = this.V;
        if (bVar3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPreferenceViewModel");
            bVar3 = null;
        }
        com.scanflow.datacapture.barinternal.h.a aVar2 = bVar3.b;
        if (aVar2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("DS_EXP_MESSAGE");
            aVar2 = null;
        }
        BaseCameraCaptureScan baseCameraCaptureScan3 = this.c;
        if (baseCameraCaptureScan3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
            baseCameraCaptureScan3 = null;
        }
        final Function1 function2 = new Function1() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda4
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return BaseCameraCaptureScan.b(this.f$0, (String) obj);
            }
        };
        aVar2.observe(baseCameraCaptureScan3, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda5
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                BaseCameraCaptureScan.c(function2, obj);
            }
        });
        com.scanflow.datacapture.barinternal.h.b bVar4 = this.V;
        if (bVar4 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPreferenceViewModel");
            bVar4 = null;
        }
        com.scanflow.datacapture.barinternal.h.a aVar3 = bVar4.d;
        if (aVar3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("DS_RESTRICT_SCAN");
            aVar3 = null;
        }
        BaseCameraCaptureScan baseCameraCaptureScan4 = this.c;
        if (baseCameraCaptureScan4 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
            baseCameraCaptureScan4 = null;
        }
        final Function1 function3 = new Function1() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda6
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return BaseCameraCaptureScan.a(this.f$0, (Boolean) obj);
            }
        };
        aVar3.observe(baseCameraCaptureScan4, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda7
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                BaseCameraCaptureScan.d(function3, obj);
            }
        });
        com.scanflow.datacapture.barinternal.h.b bVar5 = this.V;
        if (bVar5 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("sharedPreferenceViewModel");
            bVar5 = null;
        }
        com.scanflow.datacapture.barinternal.h.a aVar4 = bVar5.c;
        if (aVar4 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("DS_DEFAULT_EXPDAY");
            aVar4 = null;
        }
        BaseCameraCaptureScan baseCameraCaptureScan5 = this.c;
        if (baseCameraCaptureScan5 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
            baseCameraCaptureScan5 = null;
        }
        final Function1 function4 = new Function1() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda8
            @Override // kotlin.jvm.functions.Function1
            public final Object invoke(Object obj) {
                return BaseCameraCaptureScan.a(this.f$0, (Integer) obj);
            }
        };
        aVar4.observe(baseCameraCaptureScan5, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda9
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) {
                BaseCameraCaptureScan.a(function4, obj);
            }
        });
        SharedPreferences sharedPreferences3 = this.Q;
        if (sharedPreferences3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("preference");
            sharedPreferences3 = null;
        }
        String strValueOf = String.valueOf(sharedPreferences3.getString("uniqueid", ""));
        this.R = strValueOf;
        if (strValueOf.length() == 0) {
            this.R = "PlayStore/PROD_" + UUID.randomUUID();
            SharedPreferences sharedPreferences4 = this.Q;
            if (sharedPreferences4 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("preference");
                sharedPreferences4 = null;
            }
            SharedPreferences.Editor editorEdit2 = sharedPreferences4.edit();
            String str2 = this.R;
            if (str2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("uniqueid");
                str2 = null;
            }
            editorEdit2.putString("uniqueid", str2);
            editorEdit2.commit();
        }
        Activity activity10 = this.b;
        if (activity10 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity10 = null;
        }
        StringsKt.equals$default(activity10.getPackageName(), "com.scanflow.demoapp", false, 2, null);
        ScanflowLog scanflowLog = ScanflowLog.INSTANCE;
        scanflowLog.enable(false);
        if (this.f == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
        }
        d();
        Activity activity11 = this.a;
        if (activity11 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity11 = null;
        }
        Resources resources = activity11.getResources();
        DisplayMetrics displayMetrics = resources != null ? resources.getDisplayMetrics() : null;
        int i2 = displayMetrics != null ? displayMetrics.widthPixels : 480;
        int i3 = displayMetrics != null ? displayMetrics.heightPixels : 640;
        if (i2 < i3) {
            size = ((double) (((float) i2) / ((float) i3))) > 0.7d ? new Size(i2, (i2 / 3) * 4) : new Size(i2, (i2 / 9) * 16);
        } else {
            size = ((double) (((float) i3) / ((float) i2))) > 0.7d ? new Size((i3 / 3) * 4, i3) : new Size((i3 / 9) * 16, i3);
        }
        this.k = size;
        StringCompanionObject stringCompanionObject = StringCompanionObject.INSTANCE;
        String str3 = String.format("DisplayMetrics : %dx%d", Arrays.copyOf(new Object[]{Integer.valueOf(i2), Integer.valueOf(i3)}, 2));
        Intrinsics.checkNotNullExpressionValue(str3, "format(...)");
        scanflowLog.v("DefaultCameraScan", str3);
        scanflowLog.v("DefaultCameraScan", "TargetSize: " + this.k);
        Activity activity12 = this.b;
        if (activity12 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity12 = null;
        }
        StringsKt.equals$default(activity12.getPackageName(), "com.scanflow.demo.barcode", false, 2, null);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final void captureBatchInventory() {
        ImageCapture imageCapture = this.j;
        if (imageCapture != null) {
            String str = new SimpleDateFormat("yyyy-MM-dd-HH-mm-ss-SSS", Locale.US).format(Long.valueOf(System.currentTimeMillis()));
            ContentValues contentValues = new ContentValues();
            contentValues.put("_display_name", str);
            contentValues.put("mime_type", "image/jpeg");
            if (Build.VERSION.SDK_INT > 28) {
                contentValues.put("relative_path", "Pictures/PATH");
            }
            Activity activity = this.b;
            Activity activity2 = null;
            if (activity == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mActivity");
                activity = null;
            }
            ImageCapture.OutputFileOptions outputFileOptionsBuild = new ImageCapture.OutputFileOptions.Builder(activity.getContentResolver(), MediaStore.Images.Media.EXTERNAL_CONTENT_URI, contentValues).build();
            Intrinsics.checkNotNullExpressionValue(outputFileOptionsBuild, "build(...)");
            Activity activity3 = this.b;
            if (activity3 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            } else {
                activity2 = activity3;
            }
            imageCapture.takePicture(outputFileOptionsBuild, ContextCompat.getMainExecutor(activity2), new a(this));
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final void captureToScan() {
        this.H = true;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader doValidateLicense() throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, ParseException, InvalidAlgorithmParameterException {
        NetworkCapabilities networkCapabilities;
        if (!this.q0) {
            Activity context = this.b;
            if (context == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mActivity");
                context = null;
            }
            Intrinsics.checkNotNullParameter(context, "context");
            Object systemService = context.getSystemService("connectivity");
            Intrinsics.checkNotNull(systemService, "null cannot be cast to non-null type android.net.ConnectivityManager");
            ConnectivityManager connectivityManager = (ConnectivityManager) systemService;
            Network activeNetwork = connectivityManager.getActiveNetwork();
            this.W = activeNetwork != null && (networkCapabilities = connectivityManager.getNetworkCapabilities(activeNetwork)) != null && networkCapabilities.hasCapability(12) && networkCapabilities.hasCapability(16);
            b(this.X);
        }
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader doValidateLicenseWithRetry() throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
        if (!this.q0) {
            a(this.X);
        }
        return this;
    }

    public final void e() {
        CameraInfo cameraInfo;
        ExposureState exposureState;
        CameraInfo cameraInfo2;
        ExposureState exposureState2;
        Camera camera = this.h;
        boolean zIsExposureCompensationSupported = (camera == null || (cameraInfo2 = camera.getCameraInfo()) == null || (exposureState2 = cameraInfo2.getExposureState()) == null) ? false : exposureState2.isExposureCompensationSupported();
        Camera camera2 = this.h;
        Range<Integer> exposureCompensationRange = (camera2 == null || !zIsExposureCompensationSupported || (cameraInfo = camera2.getCameraInfo()) == null || (exposureState = cameraInfo.getExposureState()) == null) ? null : exposureState.getExposureCompensationRange();
        if (exposureCompensationRange == null) {
            Slider slider = this.n;
            if (slider != null) {
                slider.setVisibility(8);
            }
            Slider slider2 = this.n;
            if (slider2 != null) {
                slider2.setEnabled(false);
                return;
            }
            return;
        }
        Slider slider3 = this.n;
        if (slider3 != null) {
            slider3.setEnabled(true);
        }
        float fIntValue = ((Number) exposureCompensationRange.getUpper()).intValue();
        this.M = fIntValue;
        this.N = fIntValue > 0.0f ? fIntValue / 100 : 1.0f;
        Slider slider4 = this.n;
        if (slider4 != null) {
            slider4.setValueFrom(0.0f);
        }
        Slider slider5 = this.n;
        if (slider5 != null) {
            slider5.setValueTo(this.M);
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader enableSplitView(boolean z) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void enableTorch(boolean z) {
        Camera camera;
        CameraControl cameraControl;
        if (this.h == null || !hasFlashUnit() || (camera = this.h) == null || (cameraControl = camera.getCameraControl()) == null) {
            return;
        }
        cameraControl.enableTorch(z);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader enableTouchZoom(boolean z) {
        return this;
    }

    @SuppressLint({"UnsafeOptInUsageError"})
    public final void f() {
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "startCamerafunction()");
        Activity activity = null;
        if (this.i0) {
            try {
                Activity activity2 = this.b;
                if (activity2 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("mActivity");
                    activity2 = null;
                }
                Object systemService = activity2.getSystemService("location");
                Intrinsics.checkNotNull(systemService, "null cannot be cast to non-null type android.location.LocationManager");
                LocationManager locationManager = (LocationManager) systemService;
                this.j0 = locationManager;
                if (locationManager != null && locationManager.isProviderEnabled("gps")) {
                    a(activity2);
                }
            } catch (Exception e2) {
                e2.printStackTrace();
            }
        }
        if (this.b == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
        }
        com.scanflow.datacapture.barinternal.j.c cVar = this.T;
        if (cVar == null) {
            Intrinsics.throwUninitializedPropertyAccessException("internetManager");
            cVar = null;
        }
        cVar.b.a.observe(this, new Observer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda13
            @Override // androidx.lifecycle.Observer
            public final void onChanged(Object obj) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, ParseException, InvalidAlgorithmParameterException {
                BaseCameraCaptureScan.a(this.f$0, (d) obj);
            }
        });
        com.scanflow.datacapture.barinternal.j.c cVar2 = this.T;
        if (cVar2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("internetManager");
            cVar2 = null;
        }
        cVar2.a.getClass();
        NetworkRequest networkRequestBuild = new NetworkRequest.Builder().addCapability(12).addCapability(13).addTransportType(1).addTransportType(0).addTransportType(3).build();
        Intrinsics.checkNotNullExpressionValue(networkRequestBuild, "build(...)");
        cVar2.c.registerNetworkCallback(networkRequestBuild, cVar2.b);
        if (this.i == null) {
            this.i = new com.scanflow.datacapture.barinternal.d.a();
        }
        ProcessCameraProvider.Companion companion = ProcessCameraProvider.Companion;
        Activity activity3 = this.b;
        if (activity3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity3 = null;
        }
        this.g = companion.getInstance(activity3);
        PreviewView previewView = this.f;
        if (previewView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
            previewView = null;
        }
        final int rotation = previewView.getDisplay().getRotation();
        this.e = (rotation == 1 || rotation == 3) ? new Size(this.d.getHeight(), this.d.getWidth()) : this.d;
        ListenableFuture<ProcessCameraProvider> listenableFuture = this.g;
        if (listenableFuture != null) {
            Runnable runnable = new Runnable() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda14
                @Override // java.lang.Runnable
                public final void run() {
                    BaseCameraCaptureScan.a(this.f$0, rotation);
                }
            };
            Activity activity4 = this.a;
            if (activity4 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mContext");
            } else {
                activity = activity4;
            }
            listenableFuture.addListener(runnable, ContextCompat.getMainExecutor(activity));
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ICamera
    public final Camera getCamera() {
        return this.h;
    }

    @Override // androidx.lifecycle.LifecycleOwner
    public final Lifecycle getLifecycle() {
        return this.z0;
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final boolean hasFlashUnit() {
        CameraInfo cameraInfo;
        Camera camera = this.h;
        return (camera == null || (cameraInfo = camera.getCameraInfo()) == null || !cameraInfo.hasFlashUnit()) ? false : true;
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final boolean isTorchEnabled() {
        CameraInfo cameraInfo;
        LiveData<Integer> torchState;
        Integer value;
        Camera camera = this.h;
        return (camera == null || (cameraInfo = camera.getCameraInfo()) == null || (torchState = cameraInfo.getTorchState()) == null || (value = torchState.getValue()) == null || value.intValue() != 1) ? false : true;
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void lineZoomIn() {
        Camera camera;
        CameraControl cameraControl;
        LiveData<ZoomState> zoomState;
        ZoomState value;
        Camera camera2 = this.h;
        if (camera2 == null) {
            return;
        }
        CameraInfo cameraInfo = camera2.getCameraInfo();
        float linearZoom = (cameraInfo == null || (zoomState = cameraInfo.getZoomState()) == null || (value = zoomState.getValue()) == null) ? 0.0f : value.getLinearZoom() + 0.1f;
        if (linearZoom > 1.0f || (camera = this.h) == null || (cameraControl = camera.getCameraControl()) == null) {
            return;
        }
        cameraControl.setLinearZoom(linearZoom);
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void lineZoomOut() {
        Camera camera;
        CameraControl cameraControl;
        LiveData<ZoomState> zoomState;
        ZoomState value;
        Camera camera2 = this.h;
        if (camera2 == null) {
            return;
        }
        CameraInfo cameraInfo = camera2.getCameraInfo();
        float linearZoom = (cameraInfo == null || (zoomState = cameraInfo.getZoomState()) == null || (value = zoomState.getValue()) == null) ? 0.0f : value.getLinearZoom() - 0.1f;
        if (linearZoom < 0.0f || (camera = this.h) == null || (cameraControl = camera.getCameraControl()) == null) {
            return;
        }
        cameraControl.setLinearZoom(linearZoom);
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void lineZoomTo(float f2) {
        CameraControl cameraControl;
        Camera camera = this.h;
        if (camera == null || (cameraControl = camera.getCameraControl()) == null) {
            return;
        }
        cameraControl.setLinearZoom(f2);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader performOneTouchClick() {
        ScanflowReader.OnOneTouchCallback onOneTouchCallback = this.o;
        if (onOneTouchCallback != null) {
            onOneTouchCallback.onStarted();
        }
        this.E = false;
        this.S = true;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ICamera
    public final void release() {
        this.m = null;
        com.scanflow.datacapture.barinternal.e.a aVar = this.A;
        if (aVar != null) {
            aVar.b();
        }
        BeepManager beepManager = this.z;
        if (beepManager != null) {
            beepManager.close();
        }
        stopCamera();
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader resetOneToManyCodes() {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setAutoExposure(boolean z) {
        this.D = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setAutoFlashlight(boolean z) {
        this.C = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setAutoZoom(boolean z) {
        this.E = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setBeepSoundResource(int i2) {
        this.O = Integer.valueOf(i2);
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setCameraResolution(ScanflowReader.CameraResolutionConfig size) {
        Intrinsics.checkNotNullParameter(size, "size");
        this.d = size.getSize();
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEchanceTextCount(int i2) {
        this.x0 = i2;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEnableDataTracking(boolean z) {
        this.f0 = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEnableLocationTracking(boolean z) {
        this.i0 = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEnableTireAngleDetection(boolean z) {
        this.h0 = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEnableTirePreProcessing(boolean z) {
        this.g0 = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setEnhanceTextResult(boolean z) {
        this.w0 = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setIsBatchScanning(boolean z) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setIsContinuousScan(boolean z) {
        this.G = z;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnBarcodeScanResultCallback(ScanflowReader.OnBarcodeScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.r = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnCameraResultCallback(ScanflowReader.OnCameraResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnIDCardScanResultCallback(ScanflowReader.OnIDCardScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.s = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnLicenseValidationCallback(ScanflowReader.OnLicenseValidationCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.x = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnOneTouchCallback(ScanflowReader.OnOneTouchCallback onOneTouchCallback) {
        Intrinsics.checkNotNullParameter(onOneTouchCallback, "onOneTouchCallback");
        this.o = onOneTouchCallback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnTextComponentScanResultCallback(ScanflowReader.OnTextComponentScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.t = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnTextComponentVinPlateScanResultCallback(ScanflowReader.OnTextComponentVinPlateScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.u = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnTextComponentVinStickerScanResultCallback(ScanflowReader.OnTextComponentVinStickerScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.v = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnTextScanResultCallback(ScanflowReader.OnTextScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.p = callback;
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOnWebServiceScanResultCallback(ScanflowReader.OnWebServiceScanResultCallback callback) {
        Intrinsics.checkNotNullParameter(callback, "callback");
        this.w = callback;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOneToManyCodes(boolean z) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setOneToManyCodesKeepCurrent(boolean z) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setPlayBeep(boolean z) {
        this.u0 = z;
        BeepManager beepManager = this.z;
        if (beepManager != null) {
            beepManager.setPlayBeep(z);
        }
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setQrBarcodeDetection(boolean z) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setSwitchCategory(String switchCategory) {
        Intrinsics.checkNotNullParameter(switchCategory, "switchCategory");
        this.y0 = switchCategory;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setVibrate(boolean z) {
        this.v0 = z;
        BeepManager beepManager = this.z;
        if (beepManager != null) {
            beepManager.setVibrate(z);
        }
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader setVinNumberColor(VinNumberColorConfig selectedVinNumberColorConfig) {
        Intrinsics.checkNotNullParameter(selectedVinNumberColorConfig, "selectedVinNumberColorConfig");
        this.B0 = selectedVinNumberColorConfig;
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ICamera
    public final void startCamera() {
        CameraInfo cameraInfo;
        CameraSelector cameraSelector;
        ListenableFuture<ProcessCameraProvider> listenableFuture;
        ProcessCameraProvider processCameraProvider;
        ProcessCameraProvider processCameraProvider2;
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "startCamera()");
        PreviewView previewView = null;
        UseCaseGroup useCaseGroup = null;
        if (this.h == null) {
            PreviewView previewView2 = this.f;
            if (previewView2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                previewView2 = null;
            }
            if (previewView2.getWidth() > 0) {
                PreviewView previewView3 = this.f;
                if (previewView3 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                } else {
                    previewView = previewView3;
                }
                if (previewView.getHeight() > 0) {
                    f();
                    return;
                }
            }
            b();
            return;
        }
        ListenableFuture<ProcessCameraProvider> listenableFuture2 = this.g;
        if (listenableFuture2 != null && (processCameraProvider2 = listenableFuture2.get()) != null) {
            processCameraProvider2.unbindAll();
        }
        Camera camera = this.h;
        if (camera != null && (cameraInfo = camera.getCameraInfo()) != null && (cameraSelector = cameraInfo.getCameraSelector()) != null && (listenableFuture = this.g) != null && (processCameraProvider = listenableFuture.get()) != null) {
            BaseCameraCaptureScan baseCameraCaptureScan = this.c;
            if (baseCameraCaptureScan == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
                baseCameraCaptureScan = null;
            }
            UseCaseGroup useCaseGroup2 = this.A0;
            if (useCaseGroup2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("useCaseGroup");
            } else {
                useCaseGroup = useCaseGroup2;
            }
            processCameraProvider.bindToLifecycle(baseCameraCaptureScan, cameraSelector, useCaseGroup);
        }
        this.z0.setCurrentState(Lifecycle.State.STARTED);
        lineZoomTo(this.F);
        e();
    }

    @Override // com.scanflow.datacapture.core.camera.ICamera
    public final void stopCamera() {
        ProcessCameraProvider processCameraProvider;
        try {
            ListenableFuture<ProcessCameraProvider> listenableFuture = this.g;
            if (listenableFuture == null || (processCameraProvider = listenableFuture.get()) == null) {
                return;
            }
            processCameraProvider.unbindAll();
        } catch (Exception e2) {
            e2.printStackTrace();
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader
    public final ScanflowReader updateConfidenceValue(float f2) {
        return this;
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void zoomIn() {
        Camera camera = this.h;
        if (camera != null) {
            Intrinsics.checkNotNull(camera);
            ZoomState value = camera.getCameraInfo().getZoomState().getValue();
            Intrinsics.checkNotNull(value);
            float zoomRatio = value.getZoomRatio() + 0.1f;
            Camera camera2 = this.h;
            Intrinsics.checkNotNull(camera2);
            ZoomState value2 = camera2.getCameraInfo().getZoomState().getValue();
            Intrinsics.checkNotNull(value2);
            if (zoomRatio <= value2.getMaxZoomRatio()) {
                Camera camera3 = this.h;
                Intrinsics.checkNotNull(camera3);
                camera3.getCameraControl().setZoomRatio(zoomRatio);
            }
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void zoomOut() {
        Camera camera = this.h;
        if (camera != null) {
            Intrinsics.checkNotNull(camera);
            ZoomState value = camera.getCameraInfo().getZoomState().getValue();
            Intrinsics.checkNotNull(value);
            float zoomRatio = value.getZoomRatio() - 0.1f;
            Camera camera2 = this.h;
            Intrinsics.checkNotNull(camera2);
            ZoomState value2 = camera2.getCameraInfo().getZoomState().getValue();
            Intrinsics.checkNotNull(value2);
            if (zoomRatio >= value2.getMinZoomRatio()) {
                Camera camera3 = this.h;
                Intrinsics.checkNotNull(camera3);
                camera3.getCameraControl().setZoomRatio(zoomRatio);
            }
        }
    }

    @Override // com.scanflow.datacapture.core.camera.ICameraControl
    public final void zoomTo(float f2) {
        CameraControl cameraControl;
        LiveData<ZoomState> zoomState;
        Camera camera = this.h;
        if (camera == null) {
            return;
        }
        CameraInfo cameraInfo = camera.getCameraInfo();
        ZoomState value = (cameraInfo == null || (zoomState = cameraInfo.getZoomState()) == null) ? null : zoomState.getValue();
        float fCoerceAtLeast = RangesKt.coerceAtLeast(RangesKt.coerceAtMost(f2, value != null ? value.getMaxZoomRatio() : 0.0f), value != null ? value.getMinZoomRatio() : 0.0f);
        Camera camera2 = this.h;
        if (camera2 == null || (cameraControl = camera2.getCameraControl()) == null) {
            return;
        }
        cameraControl.setZoomRatio(fCoerceAtLeast);
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, Analyzer<T> analyzer) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new g(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "Session Init");
        this.m0 = "Barcode_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        c();
    }

    @SuppressLint({"ClickableViewAccessibility"})
    public final void d() {
        Activity activity = this.a;
        PreviewView previewView = null;
        if (activity == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity = null;
        }
        final ScaleGestureDetector scaleGestureDetector = new ScaleGestureDetector(activity, this.C0);
        Activity activity2 = this.a;
        if (activity2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity2 = null;
        }
        final GestureDetector gestureDetector = new GestureDetector(activity2, this.D0);
        PreviewView previewView2 = this.f;
        if (previewView2 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
        } else {
            previewView = previewView2;
        }
        previewView.setOnTouchListener(new View.OnTouchListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda0
            @Override // android.view.View.OnTouchListener
            public final boolean onTouch(View view, MotionEvent motionEvent) {
                return BaseCameraCaptureScan.a(gestureDetector, this, scaleGestureDetector, view, motionEvent);
            }
        });
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, SFCameraView sfCameraView, Analyzer<T> analyzer, float f2) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new h(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "Session Init");
        this.m0 = "Barcode_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.F = f2;
        this.X = SCANFLOW_LICENSE_KEY;
        c();
    }

    public final void a() throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
        ScanflowReader.OnLicenseValidationCallback onLicenseValidationCallback = this.x;
        if (onLicenseValidationCallback != null) {
            onLicenseValidationCallback.onLicenseFailure(ErrorMessageUtils.Error_9);
        }
        SharedPreferences sharedPreferences = this.t0;
        if (sharedPreferences == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences = null;
        }
        if (String.valueOf(sharedPreferences.getString(this.Y + this.X, "")).length() == 0) {
            a(new SubscriptionResponse(ErrorMessageUtils.Error_9, null, "Error", null, this.X));
        }
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfcamera.SFCameraView sfCameraView, Analyzer<T> analyzer, float f2) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new m(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        this.m0 = "Text_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        this.F = f2;
        c();
    }

    public final void a(Activity activity) {
        if (ContextCompat.checkSelfPermission(activity, "android.permission.ACCESS_FINE_LOCATION") == 0 || ContextCompat.checkSelfPermission(activity, "android.permission.ACCESS_COARSE_LOCATION") == 0) {
            LocationListener locationListener = new LocationListener() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda12
                @Override // android.location.LocationListener
                public final void onLocationChanged(Location location) {
                    BaseCameraCaptureScan.a(this.f$0, location);
                }
            };
            LocationManager locationManager = this.j0;
            Intrinsics.checkNotNull(locationManager);
            locationManager.requestLocationUpdates("gps", 0L, 0.0f, locationListener);
        }
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfdocument.SFCameraView sfCameraView, Analyzer<T> analyzer, float f2) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new j(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        this.m0 = "Document_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        this.F = f2;
        c();
    }

    public static final void a(BaseCameraCaptureScan baseCameraCaptureScan, Location location) {
        Intrinsics.checkNotNullParameter(location, "location");
        baseCameraCaptureScan.k0 = location.getLatitude();
        baseCameraCaptureScan.l0 = location.getLongitude();
    }

    public /* synthetic */ BaseCameraCaptureScan(Activity activity, String str, com.scanflow.datacapture.sfdocument.SFCameraView sFCameraView, Analyzer analyzer, float f2, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this(activity, str, sFCameraView, analyzer, (i2 & 16) != 0 ? 0.1f : f2);
    }

    public static final void a(BaseCameraCaptureScan baseCameraCaptureScan) {
        PreviewView previewView = baseCameraCaptureScan.f;
        if (previewView == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
            previewView = null;
        }
        previewView.addOnLayoutChangeListener(new c(baseCameraCaptureScan));
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sfidcard.SFCameraView sfCameraView, Analyzer<T> analyzer, float f2) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new i(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        this.m0 = "Id_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        this.F = f2;
        c();
    }

    public static final Unit a(BaseCameraCaptureScan baseCameraCaptureScan, Integer num) {
        num.getClass();
        baseCameraCaptureScan.getClass();
        return Unit.INSTANCE;
    }

    public /* synthetic */ BaseCameraCaptureScan(Activity activity, String str, com.scanflow.datacapture.sfidcard.SFCameraView sFCameraView, Analyzer analyzer, float f2, int i2, DefaultConstructorMarker defaultConstructorMarker) {
        this(activity, str, sFCameraView, analyzer, (i2 & 16) != 0 ? 0.1f : f2);
    }

    public static final void a(Function1 function1, Object obj) {
        function1.invoke(obj);
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sftext.SFCameraView sfCameraView, Analyzer<T> analyzer) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new k(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        this.m0 = "Text_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        c();
    }

    public static final void a(BaseCameraCaptureScan baseCameraCaptureScan, Object obj) {
        baseCameraCaptureScan.r0 = false;
    }

    public BaseCameraCaptureScan(Activity activity, String SCANFLOW_LICENSE_KEY, com.scanflow.datacapture.sftext.SFCameraView sfCameraView, Analyzer<T> analyzer, float f2) {
        Intrinsics.checkNotNullParameter(activity, "activity");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(analyzer, "analyzer");
        Size size = ScanflowReader.CameraResolutionConfig.FULL_HD_1080P.getSize();
        this.d = size;
        this.e = size;
        this.F = 0.1f;
        this.G = true;
        this.P = Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.X = "";
        this.Y = "SCANFLOW_LICENSE_PREF_NAME_";
        this.Z = "SECRET_KEY_PREF_NAME";
        this.a0 = "SALTVALUE_PREF_NAME";
        this.b0 = "MODEL_FILE_KEY_PREF_NAME";
        this.c0 = "123456789";
        this.d0 = "abcdefg";
        this.e0 = "MyDifficultPassw";
        this.m0 = "";
        this.n0 = new l(CoroutineExceptionHandler.Key);
        this.p0 = true;
        this.u0 = true;
        this.x0 = 1;
        this.y0 = "dashboard";
        LifecycleRegistry lifecycleRegistry = new LifecycleRegistry(this);
        this.z0 = lifecycleRegistry;
        this.B0 = VinNumberColorConfig.SILVER;
        this.C0 = new f(this);
        this.D0 = new e(this);
        lifecycleRegistry.setCurrentState(Lifecycle.State.CREATED);
        System.loadLibrary("opencv_java4");
        this.m0 = "Text_Capture";
        this.c = this;
        this.a = activity;
        this.b = activity;
        this.f = sfCameraView.getPreviewView();
        this.o0 = analyzer;
        this.X = SCANFLOW_LICENSE_KEY;
        this.F = f2;
        c();
    }

    public static final Unit a(BaseCameraCaptureScan baseCameraCaptureScan, String str) {
        baseCameraCaptureScan.getClass();
        return Unit.INSTANCE;
    }

    public static final Unit a(BaseCameraCaptureScan baseCameraCaptureScan, Boolean bool) {
        bool.getClass();
        baseCameraCaptureScan.getClass();
        return Unit.INSTANCE;
    }

    public final void b() {
        ScanflowLog.INSTANCE.v("DefaultCameraScan", "initCameraView()");
        Activity activity = this.b;
        if (activity == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mActivity");
            activity = null;
        }
        activity.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda11
            @Override // java.lang.Runnable
            public final void run() {
                BaseCameraCaptureScan.a(this.f$0);
            }
        });
    }

    public static final boolean a(GestureDetector gestureDetector, BaseCameraCaptureScan baseCameraCaptureScan, ScaleGestureDetector scaleGestureDetector, View view, MotionEvent event) {
        CameraControl cameraControl;
        Intrinsics.checkNotNullParameter(event, "event");
        gestureDetector.onTouchEvent(event);
        baseCameraCaptureScan.getClass();
        if (event.getPointerCount() == 1) {
            int action = event.getAction();
            if (action == 0) {
                baseCameraCaptureScan.J = true;
                baseCameraCaptureScan.K = event.getX();
                baseCameraCaptureScan.L = event.getY();
                baseCameraCaptureScan.I = System.currentTimeMillis();
            } else if (action == 1) {
                Slider slider = baseCameraCaptureScan.n;
                if (slider != null) {
                    slider.setVisibility(8);
                }
                if (baseCameraCaptureScan.J && baseCameraCaptureScan.I + ((long) BuiltinOperator.GELU) > System.currentTimeMillis()) {
                    float x = event.getX();
                    float y = event.getY();
                    if (baseCameraCaptureScan.h != null) {
                        PreviewView previewView = baseCameraCaptureScan.f;
                        if (previewView == null) {
                            Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                            previewView = null;
                        }
                        MeteringPoint meteringPointCreatePoint = previewView.getMeteringPointFactory().createPoint(x, y);
                        Intrinsics.checkNotNullExpressionValue(meteringPointCreatePoint, "createPoint(...)");
                        Camera camera = baseCameraCaptureScan.h;
                        if (camera != null && (cameraControl = camera.getCameraControl()) != null) {
                            cameraControl.startFocusAndMetering(new FocusMeteringAction.Builder(meteringPointCreatePoint).build());
                        }
                        ScanflowLog.INSTANCE.v("DefaultCameraScan", "StartFocusAndMetering (x,y): " + x + ',' + y);
                    }
                }
            } else if (action == 2) {
                float f2 = baseCameraCaptureScan.K;
                float f3 = baseCameraCaptureScan.L;
                double x2 = f2 - event.getX();
                double y2 = f3 - event.getY();
                baseCameraCaptureScan.J = ((float) Math.sqrt((y2 * y2) + (x2 * x2))) < 20.0f;
                float fAbs = Math.abs(baseCameraCaptureScan.L - event.getY());
                float fAbs2 = Math.abs(baseCameraCaptureScan.K - event.getX());
                if (fAbs > 20.0f && fAbs2 < 80.0f) {
                    if (baseCameraCaptureScan.L < event.getY()) {
                        baseCameraCaptureScan.b(true);
                    } else if (baseCameraCaptureScan.L > event.getY()) {
                        baseCameraCaptureScan.b(false);
                    }
                }
            }
        }
        return scaleGestureDetector.onTouchEvent(event);
    }

    public static final void b(Function1 function1, Object obj) {
        function1.invoke(obj);
    }

    public static final Unit b(BaseCameraCaptureScan baseCameraCaptureScan, String str) {
        baseCameraCaptureScan.getClass();
        return Unit.INSTANCE;
    }

    /* JADX WARN: Code duplicated, block: B:19:0x002e A[PHI: r0 r5
      0x002e: PHI (r0v10 float) = (r0v4 float), (r0v12 float) binds: [B:23:0x0039, B:18:0x002c] A[DONT_GENERATE, DONT_INLINE]
      0x002e: PHI (r5v6 com.google.android.material.slider.Slider) = (r5v2 com.google.android.material.slider.Slider), (r5v8 com.google.android.material.slider.Slider) binds: [B:23:0x0039, B:18:0x002c] A[DONT_GENERATE, DONT_INLINE]] */
    public final void b(boolean z) {
        float f2;
        Slider slider;
        Slider slider2 = this.n;
        if (slider2 == null || this.D) {
            return;
        }
        slider2.setVisibility(0);
        Slider slider3 = this.n;
        float f3 = 0.0f;
        float value = slider3 != null ? slider3.getValue() : 0.0f;
        if (0.0f <= value) {
            float f4 = this.M;
            if (value <= f4) {
                if (z) {
                    f2 = value - this.N;
                    slider = this.n;
                    if (slider != null) {
                        if (f2 > 0.0f) {
                            f3 = f2;
                            f2 = f3;
                        }
                        slider.setValue(f3);
                    }
                } else {
                    f2 = value + this.N;
                    slider = this.n;
                    if (slider != null) {
                        if (f2 < f4) {
                            f3 = f2;
                            f2 = f3;
                        } else {
                            f3 = f4;
                        }
                        slider.setValue(f3);
                    }
                }
                int i2 = (int) f2;
                Camera camera = this.h;
                if (camera == null || camera.getCameraInfo().getExposureState().getExposureCompensationIndex() == i2) {
                    return;
                }
                CameraControl cameraControl = camera.getCameraControl();
                if (cameraControl != null) {
                    cameraControl.setExposureCompensationIndex(i2);
                }
                ScanflowLog.INSTANCE.v("DefaultCameraScan", "EXPOSURE: " + i2);
            }
        }
    }

    public final void a(Integer num) {
        Activity activity = this.a;
        Activity activity2 = null;
        if (activity == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
            activity = null;
        }
        this.z = new BeepManager(activity, num);
        Activity activity3 = this.a;
        if (activity3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("mContext");
        } else {
            activity2 = activity3;
        }
        com.scanflow.datacapture.barinternal.e.a aVar = new com.scanflow.datacapture.barinternal.e.a(activity2);
        this.A = aVar;
        aVar.a();
        com.scanflow.datacapture.barinternal.e.a aVar2 = this.A;
        if (aVar2 != null) {
            Intrinsics.checkNotNullParameter(this, "listener");
            aVar2.e = this;
        }
    }

    @Override // com.scanflow.datacapture.barinternal.e.a.InterfaceC0036a
    public final void a(boolean z) {
        View view = this.m;
        if (view != null) {
            if (!z) {
                if (((view.getVisibility() == 0 && !isTorchEnabled()) || this.C) && this.C && isTorchEnabled()) {
                    enableTorch(false);
                    View view2 = this.m;
                    if (view2 != null) {
                        view2.setSelected(false);
                        return;
                    }
                    return;
                }
                return;
            }
            if (this.C) {
                if (isTorchEnabled()) {
                    return;
                }
                enableTorch(true);
                View view3 = this.m;
                if (view3 != null) {
                    view3.setSelected(true);
                    return;
                }
                return;
            }
            if (view.getVisibility() == 0) {
                return;
            }
            View view4 = this.m;
            if (view4 != null) {
                view4.setVisibility(0);
            }
            View view5 = this.m;
            if (view5 != null) {
                view5.setSelected(isTorchEnabled());
            }
        }
    }

    public static final void a(BaseCameraCaptureScan baseCameraCaptureScan, com.scanflow.datacapture.barinternal.j.d dVar) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, ParseException, InvalidAlgorithmParameterException {
        baseCameraCaptureScan.W = dVar.a;
        baseCameraCaptureScan.b(baseCameraCaptureScan.X);
    }

    public static final void a(final BaseCameraCaptureScan baseCameraCaptureScan, int i2) {
        Preview previewA;
        CameraSelector cameraSelectorBuild;
        CameraControl cameraControl;
        ListenableFuture<ProcessCameraProvider> listenableFuture;
        ProcessCameraProvider processCameraProvider;
        try {
            Camera cameraBindToLifecycle = null;
            UseCaseGroup useCaseGroup = null;
            cameraBindToLifecycle = null;
            cameraBindToLifecycle = null;
            if (baseCameraCaptureScan.i != null) {
                Preview.Builder targetResolution = new Preview.Builder().setTargetRotation(i2).setTargetResolution(baseCameraCaptureScan.e);
                Intrinsics.checkNotNullExpressionValue(targetResolution, "setTargetResolution(...)");
                previewA = com.scanflow.datacapture.barinternal.d.a.a(targetResolution);
            } else {
                previewA = null;
            }
            if (baseCameraCaptureScan.i != null) {
                CameraSelector.Builder builder = new CameraSelector.Builder();
                Intrinsics.checkNotNullParameter(builder, "builder");
                cameraSelectorBuild = builder.build();
                Intrinsics.checkNotNullExpressionValue(cameraSelectorBuild, "build(...)");
            } else {
                cameraSelectorBuild = null;
            }
            if (previewA != null) {
                PreviewView previewView = baseCameraCaptureScan.f;
                if (previewView == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                    previewView = null;
                }
                previewA.setSurfaceProvider(previewView.getSurfaceProvider());
            }
            com.scanflow.datacapture.barinternal.d.a aVar = baseCameraCaptureScan.i;
            Intrinsics.checkNotNull(aVar);
            ImageAnalysis.Builder backpressureStrategy = new ImageAnalysis.Builder().setTargetRotation(i2).setTargetResolution(baseCameraCaptureScan.e).setBackpressureStrategy(0);
            Intrinsics.checkNotNullExpressionValue(backpressureStrategy, "setBackpressureStrategy(...)");
            aVar.getClass();
            ImageAnalysis imageAnalysisA = com.scanflow.datacapture.barinternal.d.a.a(backpressureStrategy);
            imageAnalysisA.setAnalyzer(baseCameraCaptureScan.P, new ImageAnalysis.Analyzer() { // from class: com.scanflow.datacapture.barinternal.com.scanflow.datacapture.core.camera.BaseCameraCaptureScan$$ExternalSyntheticLambda10
                @Override // androidx.camera.core.ImageAnalysis.Analyzer
                public final void analyze(ImageProxy imageProxy) {
                    BaseCameraCaptureScan.a(this.f$0, imageProxy);
                }
            });
            if (baseCameraCaptureScan.h != null) {
                ListenableFuture<ProcessCameraProvider> listenableFuture2 = baseCameraCaptureScan.g;
                Intrinsics.checkNotNull(listenableFuture2);
                listenableFuture2.get().unbindAll();
            }
            PreviewView previewView2 = baseCameraCaptureScan.f;
            if (previewView2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                previewView2 = null;
            }
            ViewPort viewPort = previewView2.getViewPort();
            Intrinsics.checkNotNull(viewPort);
            baseCameraCaptureScan.l = viewPort;
            ImageCapture.Builder captureMode = new ImageCapture.Builder().setCaptureMode(0);
            PreviewView previewView3 = baseCameraCaptureScan.f;
            if (previewView3 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("mPreviewView");
                previewView3 = null;
            }
            baseCameraCaptureScan.j = captureMode.setTargetRotation(previewView3.getDisplay().getOrientation()).setJpegQuality(100).build();
            UseCaseGroup.Builder builder2 = new UseCaseGroup.Builder();
            Intrinsics.checkNotNull(previewA);
            UseCaseGroup.Builder builderAddUseCase = builder2.addUseCase(previewA).addUseCase(imageAnalysisA);
            ImageCapture imageCapture = baseCameraCaptureScan.j;
            Intrinsics.checkNotNull(imageCapture);
            UseCaseGroup.Builder builderAddUseCase2 = builderAddUseCase.addUseCase(imageCapture);
            ViewPort viewPort2 = baseCameraCaptureScan.l;
            if (viewPort2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("viewPort");
                viewPort2 = null;
            }
            baseCameraCaptureScan.A0 = builderAddUseCase2.setViewPort(viewPort2).build();
            if (cameraSelectorBuild != null && (listenableFuture = baseCameraCaptureScan.g) != null && (processCameraProvider = listenableFuture.get()) != null) {
                BaseCameraCaptureScan baseCameraCaptureScan2 = baseCameraCaptureScan.c;
                if (baseCameraCaptureScan2 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("mLifecycleOwner");
                    baseCameraCaptureScan2 = null;
                }
                UseCaseGroup useCaseGroup2 = baseCameraCaptureScan.A0;
                if (useCaseGroup2 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("useCaseGroup");
                } else {
                    useCaseGroup = useCaseGroup2;
                }
                cameraBindToLifecycle = processCameraProvider.bindToLifecycle(baseCameraCaptureScan2, cameraSelectorBuild, useCaseGroup);
            }
            baseCameraCaptureScan.h = cameraBindToLifecycle;
            if (cameraBindToLifecycle != null && (cameraControl = cameraBindToLifecycle.getCameraControl()) != null) {
                cameraControl.cancelFocusAndMetering();
            }
            baseCameraCaptureScan.z0.setCurrentState(Lifecycle.State.STARTED);
            baseCameraCaptureScan.lineZoomTo(baseCameraCaptureScan.F);
            baseCameraCaptureScan.e();
        } catch (Exception e2) {
            ScanflowLog.INSTANCE.v("DefaultCameraScan", String.valueOf(e2));
        }
    }

    public static final void a(BaseCameraCaptureScan baseCameraCaptureScan, ImageProxy image) {
        d dVar;
        Intrinsics.checkNotNullParameter(image, "image");
        if (baseCameraCaptureScan.p0 && !baseCameraCaptureScan.r0 && baseCameraCaptureScan.o0 != null) {
            baseCameraCaptureScan.r0 = true;
            SharedPreferences sharedPreferences = baseCameraCaptureScan.t0;
            if (sharedPreferences == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                sharedPreferences = null;
            }
            String strValueOf = String.valueOf(sharedPreferences.getString(baseCameraCaptureScan.Y + baseCameraCaptureScan.X, ""));
            Analyzer<T> analyzer = baseCameraCaptureScan.o0;
            if (analyzer != null) {
                Camera camera = baseCameraCaptureScan.h;
                Intrinsics.checkNotNull(camera);
                ScanflowReader.CameraUserConfig cameraUserConfig = new ScanflowReader.CameraUserConfig(baseCameraCaptureScan.G, baseCameraCaptureScan.H, baseCameraCaptureScan.E, baseCameraCaptureScan.S, baseCameraCaptureScan.e, baseCameraCaptureScan.W, baseCameraCaptureScan.z, strValueOf, baseCameraCaptureScan.O, baseCameraCaptureScan.u0, baseCameraCaptureScan.v0, baseCameraCaptureScan.f0, baseCameraCaptureScan.g0, baseCameraCaptureScan.h0, baseCameraCaptureScan.k0, baseCameraCaptureScan.l0, baseCameraCaptureScan.w0, baseCameraCaptureScan.x0, baseCameraCaptureScan.B0, baseCameraCaptureScan.y0);
                d dVar2 = baseCameraCaptureScan.y;
                if (dVar2 == null) {
                    Intrinsics.throwUninitializedPropertyAccessException("mOnAnalyzeListener");
                    dVar = null;
                } else {
                    dVar = dVar2;
                }
                analyzer.analyze(image, camera, cameraUserConfig, dVar, baseCameraCaptureScan.w);
            }
        }
        image.close();
    }

    public final void a(SubscriptionResponse subscriptionResponse) throws BadPaddingException, NoSuchPaddingException, IllegalBlockSizeException, NoSuchAlgorithmException, InvalidKeyException, InvalidAlgorithmParameterException {
        String json = new Gson().toJson(subscriptionResponse);
        Intrinsics.checkNotNull(json);
        SecretKeyFactory secretKeyFactory = SecretKeyFactory.getInstance("PBKDF2WithHmacSHA256");
        SharedPreferences sharedPreferences = this.t0;
        SharedPreferences sharedPreferences2 = null;
        if (sharedPreferences == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences = null;
        }
        char[] charArray = String.valueOf(sharedPreferences.getString(this.Z, "")).toCharArray();
        Intrinsics.checkNotNullExpressionValue(charArray, "toCharArray(...)");
        SharedPreferences sharedPreferences3 = this.t0;
        if (sharedPreferences3 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
            sharedPreferences3 = null;
        }
        String strValueOf = String.valueOf(sharedPreferences3.getString(this.a0, ""));
        Charset charset = Charsets.UTF_8;
        byte[] bytes = strValueOf.getBytes(charset);
        Intrinsics.checkNotNullExpressionValue(bytes, "getBytes(...)");
        SecretKeySpec secretKeySpec = new SecretKeySpec(secretKeyFactory.generateSecret(new PBEKeySpec(charArray, bytes, 65536, 256)).getEncoded(), "AES");
        Cipher cipher = Cipher.getInstance("AES/GCM/NoPadding");
        byte[] bArr = new byte[12];
        new SecureRandom().nextBytes(bArr);
        cipher.init(1, secretKeySpec, new GCMParameterSpec(128, bArr));
        byte[] bytes2 = json.getBytes(charset);
        Intrinsics.checkNotNullExpressionValue(bytes2, "getBytes(...)");
        byte[] bArrDoFinal = cipher.doFinal(bytes2);
        byte[] bArr2 = new byte[bArrDoFinal.length + 12];
        System.arraycopy(bArr, 0, bArr2, 0, 12);
        System.arraycopy(bArrDoFinal, 0, bArr2, 12, bArrDoFinal.length);
        String strEncodeToString = Base64.getEncoder().encodeToString(bArr2);
        Intrinsics.checkNotNull(strEncodeToString);
        SharedPreferences sharedPreferences4 = this.t0;
        if (sharedPreferences4 == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
        } else {
            sharedPreferences2 = sharedPreferences4;
        }
        SharedPreferences.Editor editorEdit = sharedPreferences2.edit();
        editorEdit.putString(this.Y + this.X, strEncodeToString);
        editorEdit.apply();
    }

    public static final void c(Function1 function1, Object obj) {
        function1.invoke(obj);
    }
}
