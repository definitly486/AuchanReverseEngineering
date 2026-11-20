package com.scanflow.datacapture.barcode;

import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import java.util.ArrayList;
import java.util.HashSet;

/* JADX INFO: loaded from: classes3.dex */
public abstract class SFBarcodeReader {

    public interface OnBarcodeScanResultCallback {
        void onBatchScanResultSuccess(ArrayList<ScanResultSuccess> arrayList);

        void onOneOfManyCodeResult(HashSet<OneOFManyCodesScanResults> hashSet);

        void onOneofManyCodeRemoved(OneOFManyCodesScanResults oneOFManyCodesScanResults);

        void onOneofManyCodeSelected(OneOFManyCodesScanResults oneOFManyCodesScanResults);

        void onScanBarcodeDetection(boolean z);

        void onScanResultFailure(String str);

        void onScanResultSuccess(ScanResultSuccess scanResultSuccess);
    }

    public abstract SFBarcodeReader setOnBarcodeScanResultCallback(OnBarcodeScanResultCallback onBarcodeScanResultCallback);
}
