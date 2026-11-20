package com.scanflow.datacapture.barinternal;

import com.google.mlkit.vision.barcode.BarcodeScanner;
import com.google.mlkit.vision.barcode.BarcodeScannerOptions;
import com.google.mlkit.vision.barcode.BarcodeScanning;
import java.util.ArrayList;
import kotlin.jvm.internal.Intrinsics;
import org.opencv.core.Mat;
import org.opencv.objdetect.QRCodeDetector;

/* JADX INFO: renamed from: com.scanflow.datacapture.barinternal.l, reason: case insensitive filesystem */
/* JADX INFO: loaded from: classes3.dex */
public abstract class AbstractC0094l {
    public static final BarcodeScanner a;

    static {
        new ArrayList();
        new ArrayList();
        new ArrayList();
        new Mat();
        new QRCodeDetector();
        BarcodeScannerOptions barcodeScannerOptionsBuild = new BarcodeScannerOptions.Builder().enableAllPotentialBarcodes().build();
        Intrinsics.checkNotNullExpressionValue(barcodeScannerOptionsBuild, "build(...)");
        BarcodeScanner client = BarcodeScanning.getClient(barcodeScannerOptionsBuild);
        Intrinsics.checkNotNullExpressionValue(client, "getClient(...)");
        a = client;
    }
}
