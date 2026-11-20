package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.PorterDuff;
import android.util.Log;
import com.google.android.gms.tasks.OnCompleteListener;
import com.google.android.gms.tasks.Task;
import com.google.mlkit.vision.barcode.BarcodeScanner;
import com.google.mlkit.vision.barcode.common.Barcode;
import com.google.mlkit.vision.common.InputImage;
import com.google.zxing.BinaryBitmap;
import com.google.zxing.DecodeHintType;
import com.google.zxing.LuminanceSource;
import com.google.zxing.MultiFormatReader;
import com.google.zxing.RGBLuminanceSource;
import com.google.zxing.Result;
import com.google.zxing.common.GlobalHistogramBinarizer;
import com.google.zxing.common.HybridBinarizer;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.core.camera.analyze.Analyzer;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: loaded from: classes3.dex */
public final class K extends SuspendLambda implements Function2 {
    public /* synthetic */ Object a;
    public final /* synthetic */ ArrayList b;
    public final /* synthetic */ M c;
    public final /* synthetic */ Analyzer.OnAnalyzeListener d;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public K(ArrayList arrayList, M m, Analyzer.OnAnalyzeListener onAnalyzeListener, Continuation continuation) {
        super(2, continuation);
        this.b = arrayList;
        this.c = m;
        this.d = onAnalyzeListener;
    }

    public static final void a(ArrayList arrayList, ArrayList arrayList2, int i, M m, Analyzer.OnAnalyzeListener onAnalyzeListener, B b, CoroutineScope coroutineScope, Task task) {
        Point point;
        Point point2;
        int i2;
        String displayValue;
        if (!task.isSuccessful() || ((List) task.getResult()).size() <= 0) {
            arrayList.add(new C(((B) arrayList2.get(i)).a, null, null));
        } else if (((Barcode) ((List) task.getResult()).get(0)).getFormat() != 256) {
            Point[] cornerPoints = ((Barcode) ((List) task.getResult()).get(0)).getCornerPoints();
            if (cornerPoints != null) {
                Point point3 = cornerPoints[0];
                double d = point3.x;
                double d2 = point3.y;
                Point point4 = cornerPoints[1];
                double d3 = point4.x;
                double d4 = point4.y;
                m.getClass();
                double d5 = 2;
                double dSqrt = Math.sqrt(Math.pow(d4 - d2, d5) + Math.pow(d3 - d, d5));
                Point point5 = cornerPoints[1];
                double d6 = point5.x;
                double d7 = point5.y;
                Point point6 = cornerPoints[2];
                double dSqrt2 = Math.sqrt(Math.pow(((double) point6.y) - d7, d5) + Math.pow(point6.x - d6, d5));
                Log.v("SFBarcode", "Calculate Distance - " + dSqrt + ' ' + dSqrt2);
                if (dSqrt > dSqrt2) {
                    Point point7 = cornerPoints[0];
                    point = new Point(point7.x, point7.y);
                    Point point8 = cornerPoints[1];
                    point2 = new Point(point8.x, point8.y);
                } else {
                    Point point9 = cornerPoints[1];
                    point = new Point(point9.x, point9.y);
                    Point point10 = cornerPoints[2];
                    point2 = new Point(point10.x, point10.y);
                }
                double dA = M.a(point, point2);
                Bitmap croppedBitmap = b.b;
                Intrinsics.checkNotNullParameter(croppedBitmap, "croppedBitmap");
                Bitmap croppedBitmap2 = Bitmap.createBitmap(croppedBitmap.getWidth() + 50, croppedBitmap.getHeight() + 50, Bitmap.Config.ARGB_8888);
                Intrinsics.checkNotNullExpressionValue(croppedBitmap2, "createBitmap(...)");
                Canvas canvas = new Canvas(croppedBitmap2);
                canvas.drawColor(-1, PorterDuff.Mode.LIGHTEN);
                Paint paint = new Paint();
                paint.setAntiAlias(true);
                paint.setFilterBitmap(true);
                paint.setDither(true);
                float f = 25;
                canvas.drawBitmap(croppedBitmap, f, f, paint);
                Intrinsics.checkNotNullParameter(croppedBitmap2, "croppedBitmap");
                Matrix matrix = new Matrix();
                matrix.postRotate((float) dA);
                Bitmap bitmapCreateScaledBitmap = Bitmap.createScaledBitmap(croppedBitmap2, croppedBitmap2.getWidth(), croppedBitmap2.getHeight(), true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateScaledBitmap, "createScaledBitmap(...)");
                Bitmap bitmapCreateBitmap = Bitmap.createBitmap(bitmapCreateScaledBitmap, 0, 0, bitmapCreateScaledBitmap.getWidth(), bitmapCreateScaledBitmap.getHeight(), matrix, true);
                Intrinsics.checkNotNullExpressionValue(bitmapCreateBitmap, "createBitmap(...)");
                if (((Barcode) ((List) task.getResult()).get(0)).getFormat() == 2) {
                    BarcodeScanner barcodeScanner = AbstractC0094l.a;
                    Log.v("SFBarcode", "decodeZxing - Started");
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
                            Result resultDecode = multiFormatReader.decode(new BinaryBitmap(hybridBinarizer), map);
                            if (resultDecode == null) {
                                resultDecode = multiFormatReader.decode(new BinaryBitmap(new GlobalHistogramBinarizer(rGBLuminanceSource)), map);
                            }
                            multiFormatReader.reset();
                            if (resultDecode == null) {
                                LuminanceSource luminanceSourceInvert = rGBLuminanceSource.invert();
                                try {
                                    try {
                                        Result resultDecodeWithState = multiFormatReader.decodeWithState(new BinaryBitmap(new HybridBinarizer(luminanceSourceInvert)));
                                        resultDecode = resultDecodeWithState == null ? multiFormatReader.decodeWithState(new BinaryBitmap(new GlobalHistogramBinarizer(luminanceSourceInvert))) : resultDecodeWithState;
                                        Log.v("White_points_inverted", resultDecode.getResultPoints()[0].toString());
                                        multiFormatReader.reset();
                                    } catch (Exception unused) {
                                        Log.v("processModelResultZxing", "Exception - 1");
                                        multiFormatReader.reset();
                                        displayValue = null;
                                    }
                                } catch (Throwable th) {
                                    multiFormatReader.reset();
                                    throw th;
                                }
                            }
                            String text = resultDecode.getText();
                            if (text != null) {
                                Log.v("processModelResultZxing", "decodeZxing - ".concat(text));
                            }
                            Log.v("SFBarcode", "decodeZxing - Completed");
                            displayValue = resultDecode.getText();
                        } catch (Exception unused2) {
                            Log.v("processModelResultZxing", "Exception - 0");
                        }
                        i2 = 0;
                    } catch (Throwable th2) {
                        multiFormatReader.reset();
                        throw th2;
                    }
                } else {
                    i2 = 0;
                    displayValue = ((Barcode) ((List) task.getResult()).get(0)).getDisplayValue();
                }
                Log.v("SFBarcode", "MLOutput After- " + ((Barcode) ((List) task.getResult()).get(i2)).getDisplayValue() + "  format: " + M.a(((Barcode) ((List) task.getResult()).get(i2)).getFormat()) + " zxingOutput: " + displayValue);
                if (displayValue != null) {
                    Log.v("zxingOutputBatch", displayValue);
                    if (displayValue.length() == 0) {
                        arrayList.add(new C(null, null, null));
                    } else {
                        arrayList.add(new C(((B) arrayList2.get(i)).a, (Barcode) ((List) task.getResult()).get(0), displayValue));
                    }
                } else {
                    arrayList.add(new C(null, null, null));
                }
            }
        } else {
            arrayList.add(new C(((B) arrayList2.get(i)).a, (Barcode) ((List) task.getResult()).get(0), null));
        }
        if (arrayList.size() == arrayList2.size()) {
            m.a(arrayList, onAnalyzeListener);
        }
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        K k = new K(this.b, this.c, this.d, continuation);
        k.a = obj;
        return k;
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return ((K) create((CoroutineScope) obj, (Continuation) obj2)).invokeSuspend(Unit.INSTANCE);
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Object invokeSuspend(Object obj) throws Throwable {
        IntrinsicsKt.getCOROUTINE_SUSPENDED();
        ResultKt.throwOnFailure(obj);
        final CoroutineScope coroutineScope = (CoroutineScope) this.a;
        final ArrayList arrayList = new ArrayList();
        final int i = 0;
        for (final B b : this.b) {
            InputImage inputImageFromBitmap = InputImage.fromBitmap(t.a(b.b), 0);
            Intrinsics.checkNotNullExpressionValue(inputImageFromBitmap, "fromBitmap(...)");
            new Canvas(b.b);
            Task<List<Barcode>> taskProcess = AbstractC0094l.a.process(inputImageFromBitmap);
            final ArrayList arrayList2 = this.b;
            final M m = this.c;
            final Analyzer.OnAnalyzeListener onAnalyzeListener = this.d;
            taskProcess.addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.K$$ExternalSyntheticLambda0
                @Override // com.google.android.gms.tasks.OnCompleteListener
                public final void onComplete(Task task) {
                    K.a(arrayList, arrayList2, i, m, onAnalyzeListener, b, coroutineScope, task);
                }
            });
            i++;
        }
        return arrayList;
    }
}
