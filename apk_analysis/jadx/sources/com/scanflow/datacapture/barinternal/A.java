package com.scanflow.datacapture.barinternal;

import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.Color;
import android.graphics.Matrix;
import android.graphics.Paint;
import android.graphics.Point;
import android.graphics.PorterDuff;
import android.graphics.RectF;
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
import com.scanflow.datacapture.barcode.SFBarcodeReader;
import com.scanflow.datacapture.barinternal.kotlin.ResultKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.coroutines.intrinsics.IntrinsicsKt;
import com.scanflow.datacapture.barinternal.kotlin.text.StringsKt;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import com.scanflow.datacapture.utils.BarcodeFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import kotlin.coroutines.Continuation;
import kotlin.coroutines.jvm.internal.SuspendLambda;
import kotlin.jvm.functions.Function2;
import kotlin.jvm.internal.Intrinsics;
import kotlinx.coroutines.CoroutineScope;

/* JADX INFO: loaded from: classes3.dex */
public final class A extends SuspendLambda implements Function2 {
    public /* synthetic */ Object a;
    public final /* synthetic */ ArrayList b;
    public final /* synthetic */ com.scanflow.datacapture.barcode.b c;

    /* JADX WARN: 'super' call moved to the top of the method (can break code semantics) */
    public A(ArrayList arrayList, com.scanflow.datacapture.barcode.b bVar, Continuation continuation) {
        super(2, continuation);
        this.b = arrayList;
        this.c = bVar;
    }

    /* JADX WARN: Code duplicated, block: B:103:0x0429  */
    /* JADX WARN: Code duplicated, block: B:107:0x0436  */
    /* JADX WARN: Code duplicated, block: B:108:0x043a  */
    /* JADX WARN: Code duplicated, block: B:116:0x0314 A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:118:0x032c A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:119:0x031e A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:120:0x032c A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:122:0x02fa A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:123:0x02fa A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:124:0x02fa A[SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:126:? A[RETURN, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:127:? A[RETURN, SYNTHETIC] */
    /* JADX WARN: Code duplicated, block: B:49:0x0261  */
    /* JADX WARN: Code duplicated, block: B:51:0x026c  */
    /* JADX WARN: Code duplicated, block: B:53:0x0277  */
    /* JADX WARN: Code duplicated, block: B:54:0x0295  */
    /* JADX WARN: Code duplicated, block: B:59:0x02d9  */
    /* JADX WARN: Code duplicated, block: B:61:0x02e7  */
    /* JADX WARN: Code duplicated, block: B:64:0x0300  */
    /* JADX WARN: Code duplicated, block: B:68:0x0318  */
    /* JADX WARN: Code duplicated, block: B:76:0x0333  */
    /* JADX WARN: Code duplicated, block: B:83:0x03ac  */
    /* JADX WARN: Code duplicated, block: B:86:0x03bd  */
    /* JADX WARN: Code duplicated, block: B:87:0x03c0  */
    /* JADX WARN: Code duplicated, block: B:89:0x03c4  */
    /* JADX WARN: Code duplicated, block: B:90:0x03c9  */
    /* JADX WARN: Code duplicated, block: B:92:0x03cc  */
    /* JADX WARN: Code duplicated, block: B:96:0x03d6  */
    public static final void a(ArrayList batchScanningResultList, ArrayList arrayList, int i, com.scanflow.datacapture.barcode.b bVar, B b, CoroutineScope coroutineScope, Task task) {
        String str;
        ArrayList<ScanResultSuccess> arrayList2;
        Iterator it;
        SFBarcodeReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback;
        C c;
        ArrayList arrayList3;
        Barcode barcode;
        String string;
        int color;
        Barcode barcode2;
        String displayValue;
        String displayValue2;
        Point point;
        Point point2;
        String displayValue3;
        if (!task.isSuccessful() || ((List) task.getResult()).size() <= 0) {
            str = null;
            batchScanningResultList.add(new C(((B) arrayList.get(i)).a, null, null));
        } else if (((Barcode) ((List) task.getResult()).get(0)).getFormat() != 256) {
            Point[] cornerPoints = ((Barcode) ((List) task.getResult()).get(0)).getCornerPoints();
            if (cornerPoints != null) {
                Point point3 = cornerPoints[0];
                double d = point3.x;
                double d2 = point3.y;
                Point point4 = cornerPoints[1];
                double d3 = point4.x;
                double d4 = point4.y;
                bVar.getClass();
                double d5 = d3 - d;
                double d6 = 2;
                double dSqrt = Math.sqrt(Math.pow(d4 - d2, d6) + Math.pow(d5, d6));
                Point point5 = cornerPoints[1];
                double d7 = point5.x;
                double d8 = point5.y;
                Point point6 = cornerPoints[2];
                double dSqrt2 = Math.sqrt(Math.pow(((double) point6.y) - d8, d6) + Math.pow(point6.x - d7, d6));
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
                double dA = com.scanflow.datacapture.barcode.b.a(point, point2);
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
                                        displayValue3 = null;
                                        if (displayValue3 != null) {
                                            Log.v("zxingOutputBatch", displayValue3);
                                            if (displayValue3.length() == 0) {
                                                batchScanningResultList.add(new C(null, null, null));
                                            } else {
                                                batchScanningResultList.add(new C(((B) arrayList.get(i)).a, (Barcode) ((List) task.getResult()).get(0), displayValue3));
                                            }
                                        } else {
                                            batchScanningResultList.add(new C(null, null, null));
                                        }
                                        str = null;
                                        if (batchScanningResultList.size() == arrayList.size()) {
                                            bVar.getClass();
                                            Intrinsics.checkNotNullParameter(batchScanningResultList, "batchScanningResultList");
                                            if (batchScanningResultList.size() > 0) {
                                                bVar.a();
                                                return;
                                            }
                                            arrayList2 = new ArrayList<>();
                                            bVar.o.clear();
                                            it = batchScanningResultList.iterator();
                                            Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
                                            while (it.hasNext()) {
                                                Object next = it.next();
                                                Intrinsics.checkNotNullExpressionValue(next, "next(...)");
                                                c = (C) next;
                                                arrayList3 = new ArrayList();
                                                barcode = c.b;
                                                if (barcode == null) {
                                                    if (c.c != null) {
                                                        if (barcode.getDisplayValue() != null) {
                                                            displayValue2 = barcode.getDisplayValue();
                                                            Intrinsics.checkNotNull(displayValue2);
                                                            if (displayValue2.length() == 0) {
                                                            }
                                                        }
                                                    }
                                                    string = c.c;
                                                    if (string == null) {
                                                        String displayValue4 = barcode.getDisplayValue();
                                                        Intrinsics.checkNotNull(displayValue4);
                                                        string = StringsKt.trimStart(StringsKt.replace$default(displayValue4, "\u001d", " ", false, 4, (Object) null)).toString();
                                                    }
                                                    BarcodeFormat barcodeFormatA = com.scanflow.datacapture.barcode.b.a(barcode.getFormat());
                                                    RectF rectF = c.a;
                                                    Intrinsics.checkNotNull(rectF);
                                                    arrayList2.add(new ScanResultSuccess(string, barcodeFormatA, false, arrayList3, rectF, bVar.q));
                                                    String displayValue5 = barcode.getDisplayValue();
                                                    Intrinsics.checkNotNull(displayValue5);
                                                    OneOFManyCodesScanResults oneOFManyCodesScanResults = new OneOFManyCodesScanResults(displayValue5, com.scanflow.datacapture.barcode.b.a(barcode.getFormat()).name());
                                                    String displayValue6 = barcode.getDisplayValue();
                                                    Intrinsics.checkNotNull(displayValue6);
                                                    C0084b c0084b = new C0084b(displayValue6, com.scanflow.datacapture.barcode.b.a(barcode.getFormat()).name(), 0.5f, c.a);
                                                    if (bVar.h) {
                                                        color = Color.parseColor("#1ab3fb");
                                                    } else {
                                                        color = Color.parseColor("#1ab3fb");
                                                    }
                                                    c0084b.f = color;
                                                    if (c.b.getFormat() == 2) {
                                                        displayValue = c.c;
                                                    } else {
                                                        barcode2 = c.b;
                                                        if (barcode2 != null) {
                                                            displayValue = barcode2.getDisplayValue();
                                                        } else {
                                                            displayValue = str;
                                                        }
                                                    }
                                                    if (displayValue == null) {
                                                        if (c.a == null) {
                                                        }
                                                        bVar.n.add(displayValue);
                                                    }
                                                    bVar.o.add(c0084b);
                                                }
                                            }
                                            onBarcodeScanResultCallback = bVar.a;
                                            if (onBarcodeScanResultCallback != null) {
                                                onBarcodeScanResultCallback.onBatchScanResultSuccess(arrayList2);
                                            }
                                        }
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
                            displayValue3 = resultDecode.getText();
                        } catch (Exception unused2) {
                            Log.v("processModelResultZxing", "Exception - 0");
                        }
                    } catch (Throwable th2) {
                        multiFormatReader.reset();
                        throw th2;
                    }
                } else {
                    displayValue3 = ((Barcode) ((List) task.getResult()).get(0)).getDisplayValue();
                }
                if (displayValue3 != null) {
                    Log.v("zxingOutputBatch", displayValue3);
                    if (displayValue3.length() == 0) {
                        batchScanningResultList.add(new C(null, null, null));
                    } else {
                        batchScanningResultList.add(new C(((B) arrayList.get(i)).a, (Barcode) ((List) task.getResult()).get(0), displayValue3));
                    }
                } else {
                    batchScanningResultList.add(new C(null, null, null));
                }
            }
            str = null;
        } else {
            str = null;
            batchScanningResultList.add(new C(((B) arrayList.get(i)).a, (Barcode) ((List) task.getResult()).get(0), null));
        }
        if (batchScanningResultList.size() == arrayList.size()) {
            bVar.getClass();
            Intrinsics.checkNotNullParameter(batchScanningResultList, "batchScanningResultList");
            if (batchScanningResultList.size() > 0) {
                bVar.a();
                return;
            }
            arrayList2 = new ArrayList<>();
            bVar.o.clear();
            it = batchScanningResultList.iterator();
            Intrinsics.checkNotNullExpressionValue(it, "iterator(...)");
            while (it.hasNext()) {
                Object next2 = it.next();
                Intrinsics.checkNotNullExpressionValue(next2, "next(...)");
                c = (C) next2;
                arrayList3 = new ArrayList();
                barcode = c.b;
                if (barcode == null) {
                    if (c.c != null) {
                        if (barcode.getDisplayValue() != null) {
                            displayValue2 = barcode.getDisplayValue();
                            Intrinsics.checkNotNull(displayValue2);
                            if (displayValue2.length() == 0) {
                            }
                        }
                    }
                    string = c.c;
                    if (string == null) {
                        String displayValue7 = barcode.getDisplayValue();
                        Intrinsics.checkNotNull(displayValue7);
                        string = StringsKt.trimStart(StringsKt.replace$default(displayValue7, "\u001d", " ", false, 4, (Object) null)).toString();
                    }
                    BarcodeFormat barcodeFormatA2 = com.scanflow.datacapture.barcode.b.a(barcode.getFormat());
                    RectF rectF2 = c.a;
                    Intrinsics.checkNotNull(rectF2);
                    arrayList2.add(new ScanResultSuccess(string, barcodeFormatA2, false, arrayList3, rectF2, bVar.q));
                    String displayValue8 = barcode.getDisplayValue();
                    Intrinsics.checkNotNull(displayValue8);
                    OneOFManyCodesScanResults oneOFManyCodesScanResults2 = new OneOFManyCodesScanResults(displayValue8, com.scanflow.datacapture.barcode.b.a(barcode.getFormat()).name());
                    String displayValue9 = barcode.getDisplayValue();
                    Intrinsics.checkNotNull(displayValue9);
                    C0084b c0084b2 = new C0084b(displayValue9, com.scanflow.datacapture.barcode.b.a(barcode.getFormat()).name(), 0.5f, c.a);
                    if (bVar.h || bVar.p.contains(oneOFManyCodesScanResults2)) {
                        color = Color.parseColor("#1ab3fb");
                    } else {
                        color = Color.parseColor("#FFFFFF");
                    }
                    c0084b2.f = color;
                    if (c.b.getFormat() == 2) {
                        displayValue = c.c;
                    } else {
                        barcode2 = c.b;
                        if (barcode2 != null) {
                            displayValue = barcode2.getDisplayValue();
                        } else {
                            displayValue = str;
                        }
                    }
                    if (displayValue == null) {
                        if (c.a == null && displayValue.length() != 0 && (!bVar.n.contains(displayValue) || bVar.h)) {
                            Log.v("batchScanningResult", "scannedMatrixDataList.contains(it): " + bVar.n.contains(displayValue) + ' ' + bVar.h);
                            Log.v("batchScanningResult", "batchScanningResult: " + c.a + ' ' + c.c);
                        }
                        bVar.n.add(displayValue);
                    }
                    bVar.o.add(c0084b2);
                }
            }
            onBarcodeScanResultCallback = bVar.a;
            if (onBarcodeScanResultCallback != null) {
                onBarcodeScanResultCallback.onBatchScanResultSuccess(arrayList2);
            }
        }
    }

    @Override // kotlin.coroutines.jvm.internal.BaseContinuationImpl
    public final Continuation create(Object obj, Continuation continuation) {
        A a = new A(this.b, this.c, continuation);
        a.a = obj;
        return a;
    }

    @Override // kotlin.jvm.functions.Function2
    public final Object invoke(Object obj, Object obj2) {
        return ((A) create((CoroutineScope) obj, (Continuation) obj2)).invokeSuspend(Unit.INSTANCE);
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
            final com.scanflow.datacapture.barcode.b bVar = this.c;
            taskProcess.addOnCompleteListener(new OnCompleteListener() { // from class: com.scanflow.datacapture.barinternal.A$$ExternalSyntheticLambda0
                @Override // com.google.android.gms.tasks.OnCompleteListener
                public final void onComplete(Task task) {
                    A.a(arrayList, arrayList2, i, bVar, b, coroutineScope, task);
                }
            });
            i++;
        }
        return arrayList;
    }
}
