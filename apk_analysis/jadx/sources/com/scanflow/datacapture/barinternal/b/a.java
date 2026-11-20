package com.scanflow.datacapture.barinternal.b;

import android.app.Activity;
import android.content.SharedPreferences;
import android.graphics.Bitmap;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Rect;
import android.util.Log;
import android.util.Size;
import android.view.SurfaceView;
import androidx.camera.core.Camera;
import androidx.camera.core.ImageProxy;
import androidx.lifecycle.MutableLiveData;
import androidx.security.crypto.EncryptedSharedPreferences;
import androidx.security.crypto.MasterKey;
import com.google.gson.Gson;
import com.scanflow.datacapture.R;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.text.Charsets;
import com.scanflow.datacapture.barinternal.kotlinx.coroutines.CoroutineExceptionHandler;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.model.LowLightResponse;
import com.scanflow.datacapture.model.subscription.Result;
import com.scanflow.datacapture.model.subscription.SubscriptionResponse;
import com.scanflow.datacapture.sfcamera.SFCameraView;
import com.scanflow.datacapture.sfcamera.SFTextOverlay;
import com.scanflow.datacapture.utils.ErrorMessageUtils;
import com.scanflow.datacapture.utils.ScanflowLog;
import java.nio.charset.Charset;
import java.security.InvalidAlgorithmParameterException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;
import java.text.SimpleDateFormat;
import java.util.Base64;
import java.util.Date;
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
import kotlin.coroutines.AbstractCoroutineContextElement;
import kotlin.coroutines.CoroutineContext;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes.dex */
public final class a implements Analyzer {
    public final int a;
    public final int b;
    public final MutableLiveData c;
    public final SFCameraView d;
    public final Activity e;
    public ScanflowReader.OnCameraResultCallback f;
    public boolean g;
    public boolean h;
    public boolean i;
    public final AtomicBoolean j;
    public final SharedPreferences k;
    public final String l;
    public final String m;
    public boolean n;

    /* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.b.a$a, reason: collision with other inner class name */
    public static final class C0035a extends AbstractCoroutineContextElement implements CoroutineExceptionHandler {
        public C0035a(CoroutineExceptionHandler.Key key) {
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

    public a(Activity mActivity, SFCameraView sfCameraView, String SCANFLOW_LICENSE_KEY) {
        Integer numTextCaptureWidthPercentage;
        Intrinsics.checkNotNullParameter(mActivity, "mActivity");
        Intrinsics.checkNotNullParameter(sfCameraView, "sfCameraView");
        Intrinsics.checkNotNullParameter(SCANFLOW_LICENSE_KEY, "SCANFLOW_LICENSE_KEY");
        this.a = 5;
        this.b = 90;
        MutableLiveData mutableLiveData = new MutableLiveData();
        mutableLiveData.setValue(new Pair(90, 5));
        this.c = mutableLiveData;
        new Size(1080, 1920);
        Executors.newSingleThreadExecutor();
        System.currentTimeMillis();
        this.h = true;
        Color.parseColor("#2256DE");
        Color.parseColor("#FF543E");
        Color.parseColor("#FFAF4D");
        Color.parseColor("#3098F1");
        this.j = new AtomicBoolean(false);
        this.l = "SECRET_KEY_PREF_NAME";
        this.m = "SALTVALUE_PREF_NAME";
        new C0035a(CoroutineExceptionHandler.Key);
        this.d = sfCameraView;
        this.e = mActivity;
        MasterKey masterKeyBuild = new MasterKey.Builder(mActivity, "_androidx_security_master_key_").setKeyScheme(MasterKey.KeyScheme.AES256_GCM).build();
        SharedPreferences sharedPreferences = null;
        if (masterKeyBuild == null) {
            Intrinsics.throwUninitializedPropertyAccessException("masterKey");
            masterKeyBuild = null;
        }
        SharedPreferences sharedPreferencesCreate = EncryptedSharedPreferences.create(mActivity, SCANFLOW_LICENSE_KEY, masterKeyBuild, EncryptedSharedPreferences.PrefKeyEncryptionScheme.AES256_SIV, EncryptedSharedPreferences.PrefValueEncryptionScheme.AES256_GCM);
        this.k = sharedPreferencesCreate;
        if (sharedPreferencesCreate == null) {
            Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
        } else {
            sharedPreferences = sharedPreferencesCreate;
        }
        SharedPreferences.Editor editorEdit = sharedPreferences.edit();
        editorEdit.putString("MODEL_FILE_KEY_PREF_NAME", "WN*J8yH19c9szb9#");
        editorEdit.apply();
        boolean zBooleanValue = sfCameraView.isBorderCornersRounded().booleanValue();
        int iIntValue = sfCameraView.mTopLeftColor().intValue();
        int iIntValue2 = sfCameraView.mTopRightColor().intValue();
        int iIntValue3 = sfCameraView.mBottomLeftColor().intValue();
        int iIntValue4 = sfCameraView.mBottomRightColor().intValue();
        ScanflowLog.INSTANCE.enable(false);
        Integer numTextCaptureHeightPercentage = sfCameraView.textCaptureHeightPercentage();
        if ((numTextCaptureHeightPercentage == null || numTextCaptureHeightPercentage.intValue() != 100) && ((numTextCaptureWidthPercentage = sfCameraView.textCaptureWidthPercentage()) == null || numTextCaptureWidthPercentage.intValue() != 100)) {
            Integer numTextCaptureHeightPercentage2 = sfCameraView.textCaptureHeightPercentage();
            this.b = numTextCaptureHeightPercentage2.intValue();
            Integer numTextCaptureWidthPercentage2 = sfCameraView.textCaptureWidthPercentage();
            this.a = numTextCaptureWidthPercentage2.intValue();
            MutableLiveData mutableLiveData2 = new MutableLiveData();
            mutableLiveData2.setValue(new Pair(numTextCaptureHeightPercentage2, numTextCaptureWidthPercentage2));
            this.c = mutableLiveData2;
        }
        SFTextOverlay sFTextOverlay = SFTextOverlay.INSTANCE;
        SurfaceView surfaceView = sfCameraView.getSurfaceView();
        Intrinsics.checkNotNullExpressionValue(surfaceView, "getSurfaceView(...)");
        sFTextOverlay.setTextCaptureOverlay(surfaceView, this.b, this.a, iIntValue, iIntValue2, iIntValue3, iIntValue4, zBooleanValue);
        BeepManager beepManager = new BeepManager(mActivity, Integer.valueOf(R.raw.beep));
        beepManager.setVibrate(false);
        beepManager.setPlayBeep(true);
    }

    public static final void a(a aVar) {
        SFCameraView sFCameraView = aVar.d;
        if (sFCameraView != null) {
            sFCameraView.setExpiredVisibility(Boolean.TRUE, ErrorMessageUtils.Error_19);
        }
    }

    public static final void b(a aVar) {
        SFCameraView sFCameraView = aVar.d;
        if (sFCameraView != null) {
            sFCameraView.setExpiredVisibility(Boolean.TRUE, ErrorMessageUtils.Error_13);
        }
    }

    public static final void c(a aVar) {
        SFCameraView sFCameraView = aVar.d;
        if (sFCameraView != null) {
            sFCameraView.setExpiredVisibility(Boolean.FALSE, "Valid License");
        }
    }

    /* JADX WARN: Multi-variable type inference failed */
    @Override // com.scanflow.datacapture.core.camera.analyze.Analyzer
    public final void analyze(ImageProxy imageProxy, Camera mCamera, ScanflowReader.CameraUserConfig cameraUserConfig, Analyzer.OnAnalyzeListener listener, Object obj) {
        String subscriptionEndDate;
        Intrinsics.checkNotNullParameter(imageProxy, "imageProxy");
        Intrinsics.checkNotNullParameter(mCamera, "mCamera");
        Intrinsics.checkNotNullParameter(cameraUserConfig, "cameraUserConfig");
        Intrinsics.checkNotNullParameter(listener, "listener");
        try {
            this.g = cameraUserConfig.isNetworkAvailable();
            this.h = cameraUserConfig.isContinuousScan();
            this.i = cameraUserConfig.isPerformCaptureScan();
            if (!this.j.get()) {
                String licenseInfo = cameraUserConfig.getLicenseInfo();
                if (licenseInfo.length() == 0 && !this.g) {
                    Activity activity = this.e;
                    if (activity != null) {
                        activity.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.b.a$$ExternalSyntheticLambda0
                            @Override // java.lang.Runnable
                            public final void run() {
                                a.a(this.f$0);
                            }
                        });
                    }
                    listener.onLicenseFailed(ErrorMessageUtils.Error_19);
                    return;
                }
                if (licenseInfo.length() == 0 && this.g) {
                    listener.onLicenseFailed("InProgress");
                    return;
                }
                Object objFromJson = new Gson().fromJson(a(licenseInfo), (Class<Object>) SubscriptionResponse.class);
                Intrinsics.checkNotNullExpressionValue(objFromJson, "fromJson(...)");
                final SubscriptionResponse subscriptionResponse = (SubscriptionResponse) objFromJson;
                if (subscriptionResponse.getResult() == null) {
                    Activity activity2 = this.e;
                    if (activity2 != null) {
                        activity2.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.b.a$$ExternalSyntheticLambda3
                            @Override // java.lang.Runnable
                            public final void run() {
                                a.a(this.f$0, subscriptionResponse);
                            }
                        });
                    }
                    String message = subscriptionResponse.getMessage();
                    Intrinsics.checkNotNull(message);
                    listener.onLicenseFailed(message);
                    return;
                }
                SimpleDateFormat simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd'T'HH:mm:ss.SSS");
                Result result = subscriptionResponse.getResult();
                if (new Date(System.currentTimeMillis()).after((result == null || (subscriptionEndDate = result.getSubscriptionEndDate()) == null) ? null : simpleDateFormat.parse(subscriptionEndDate))) {
                    Activity activity3 = this.e;
                    if (activity3 != null) {
                        activity3.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.b.a$$ExternalSyntheticLambda1
                            @Override // java.lang.Runnable
                            public final void run() {
                                a.b(this.f$0);
                            }
                        });
                    }
                    listener.onLicenseFailed(ErrorMessageUtils.Error_13);
                    return;
                }
                Activity activity4 = this.e;
                if (activity4 != null) {
                    activity4.runOnUiThread(new Runnable() { // from class: com.scanflow.datacapture.barinternal.b.a$$ExternalSyntheticLambda2
                        @Override // java.lang.Runnable
                        public final void run() {
                            a.c(this.f$0);
                        }
                    });
                }
                this.j.set(true);
            }
            System.currentTimeMillis();
            if (!this.h && !this.i) {
                listener.onFailure();
                return;
            }
            if (!this.n) {
                this.n = true;
            }
            int rotationDegrees = imageProxy.getImageInfo().getRotationDegrees();
            int height = imageProxy.getHeight();
            int width = imageProxy.getWidth();
            cameraUserConfig.getSelectedResolution();
            cameraUserConfig.getEnableTirePreProcessing();
            cameraUserConfig.getEnableTireAngleDetection();
            int i = width / height;
            Intrinsics.checkNotNull(obj, "null cannot be cast to non-null type com.scanflow.datacapture.core.camera.ScanflowReader.OnCameraResultCallback");
            this.f = (ScanflowReader.OnCameraResultCallback) obj;
            Bitmap bitmap = com.scanflow.datacapture.utils.a.a(imageProxy);
            Rect cropRect = new Rect(0, 0, width, height);
            Pair pair = (Pair) this.c.getValue();
            if (i > 3) {
                Intrinsics.checkNotNull(pair);
                this.c.setValue(new Pair(Integer.valueOf(((Number) pair.getFirst()).intValue() / 2), Integer.valueOf(((Number) pair.getSecond()).intValue())));
            }
            Pair pair2 = (Pair) this.c.getValue();
            Intrinsics.checkNotNull(pair2);
            int iIntValue = ((Number) pair2.getFirst()).intValue();
            int iIntValue2 = ((Number) pair2.getSecond()).intValue();
            Pair pair3 = (rotationDegrees == 90 || rotationDegrees == 270) ? new Pair(Float.valueOf(iIntValue / 100.0f), Float.valueOf(iIntValue2 / 100.0f)) : new Pair(Float.valueOf(iIntValue2 / 100.0f), Float.valueOf(iIntValue / 100.0f));
            float f = 2;
            cropRect.inset((int) ((width * ((Number) pair3.component1()).floatValue()) / f), (int) ((height * ((Number) pair3.component2()).floatValue()) / f));
            if (bitmap != null) {
                Intrinsics.checkNotNullParameter(bitmap, "bitmap");
                Intrinsics.checkNotNullParameter(cropRect, "cropRect");
                Matrix matrix = new Matrix();
                matrix.preRotate(rotationDegrees);
                Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmap, cropRect.left, cropRect.top, cropRect.width(), cropRect.height(), matrix, true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                LowLightResponse lowLightResponseA = com.scanflow.datacapture.barinternal.f.a.a.a(bitmapCreateBitmap, bitmap);
                if (lowLightResponseA != null) {
                    ScanflowReader.OnCameraResultCallback onCameraResultCallback = this.f;
                    if (onCameraResultCallback != null) {
                        onCameraResultCallback.onScanResultSuccess(lowLightResponseA.getBitmap());
                    }
                    listener.onSuccess("Success");
                    return;
                }
                if (this.i || this.h) {
                    ScanflowReader.OnCameraResultCallback onCameraResultCallback2 = this.f;
                    if (onCameraResultCallback2 != null) {
                        onCameraResultCallback2.onScanResultFailure("Scan Failed!");
                    }
                    listener.onPerformCaptureScan();
                }
            } else if (this.i || this.h) {
                ScanflowReader.OnCameraResultCallback onCameraResultCallback3 = this.f;
                if (onCameraResultCallback3 != null) {
                    onCameraResultCallback3.onScanResultFailure("Scan Failed!");
                }
                listener.onPerformCaptureScan();
            }
            listener.onFailure();
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public static final void a(a aVar, SubscriptionResponse subscriptionResponse) {
        SFCameraView sFCameraView = aVar.d;
        if (sFCameraView != null) {
            Boolean bool = Boolean.TRUE;
            String message = subscriptionResponse != null ? subscriptionResponse.getMessage() : null;
            Intrinsics.checkNotNull(message);
            sFCameraView.setExpiredVisibility(bool, message);
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
            SharedPreferences sharedPreferences = this.k;
            if (sharedPreferences == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                sharedPreferences = null;
            }
            char[] charArray = String.valueOf(sharedPreferences.getString(this.l, "")).toCharArray();
            Intrinsics.checkNotNullExpressionValue(charArray, "toCharArray(...)");
            SharedPreferences sharedPreferences2 = this.k;
            if (sharedPreferences2 == null) {
                Intrinsics.throwUninitializedPropertyAccessException("licenseSharedPreferences");
                sharedPreferences2 = null;
            }
            String strValueOf = String.valueOf(sharedPreferences2.getString(this.m, ""));
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
}
