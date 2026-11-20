package crc6477abdb5b4de0290f;

import android.os.Bundle;
import android.view.View;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.datacapture.model.ScanResultSuccess;
import crc64f03248cb510113f2.BaseFragment_1;
import java.util.ArrayList;
import java.util.HashSet;
import mono.android.IGCUserPeer;
import mono.android.TypeManager;

/* JADX INFO: loaded from: classes3.dex */
public abstract class BaseScannerFragment_1 extends BaseFragment_1 implements IGCUserPeer, ScanflowReader.OnBarcodeScanResultCallback, ScanflowReader.OnLicenseValidationCallback {
    private ArrayList refList;

    private native void n_onBatchScanResultSuccess(ArrayList arrayList);

    private native void n_onCreate(Bundle bundle);

    private native void n_onLicenseFailure(String str);

    private native void n_onLicenseSuccess(String str);

    private native void n_onOneOfManyCodeResult(HashSet hashSet);

    private native void n_onOneofManyCodeRemoved(OneOFManyCodesScanResults oneOFManyCodesScanResults);

    private native void n_onOneofManyCodeSelected(OneOFManyCodesScanResults oneOFManyCodesScanResults);

    private native void n_onScanBarcodeDetection(boolean z);

    private native void n_onScanResultFailure(String str);

    private native void n_onScanResultSuccess(ScanResultSuccess scanResultSuccess);

    private native void n_onStart();

    private native void n_onStop();

    private native void n_onViewCreated(View view, Bundle bundle);

    public BaseScannerFragment_1() {
        if (getClass() == BaseScannerFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.BaseScannerFragment`1, Auchan.Android.Net", "", this, new Object[0]);
        }
    }

    public BaseScannerFragment_1(int i) {
        super(i);
        if (getClass() == BaseScannerFragment_1.class) {
            TypeManager.Activate("Auchan.Android.Ecom.PriceChecker.BaseScannerFragment`1, Auchan.Android.Net", "System.Int32, System.Private.CoreLib", this, new Object[]{Integer.valueOf(i)});
        }
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onCreate(Bundle bundle) {
        n_onCreate(bundle);
    }

    @Override // androidx.fragment.app.Fragment
    public void onViewCreated(View view, Bundle bundle) {
        n_onViewCreated(view, bundle);
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onStart() {
        n_onStart();
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, androidx.fragment.app.Fragment
    public void onStop() {
        n_onStop();
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onBatchScanResultSuccess(ArrayList arrayList) {
        n_onBatchScanResultSuccess(arrayList);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onOneOfManyCodeResult(HashSet hashSet) {
        n_onOneOfManyCodeResult(hashSet);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onOneofManyCodeRemoved(OneOFManyCodesScanResults oneOFManyCodesScanResults) {
        n_onOneofManyCodeRemoved(oneOFManyCodesScanResults);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onOneofManyCodeSelected(OneOFManyCodesScanResults oneOFManyCodesScanResults) {
        n_onOneofManyCodeSelected(oneOFManyCodesScanResults);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onScanBarcodeDetection(boolean z) {
        n_onScanBarcodeDetection(z);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onScanResultFailure(String str) {
        n_onScanResultFailure(str);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnBarcodeScanResultCallback
    public void onScanResultSuccess(ScanResultSuccess scanResultSuccess) {
        n_onScanResultSuccess(scanResultSuccess);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnLicenseValidationCallback
    public void onLicenseFailure(String str) {
        n_onLicenseFailure(str);
    }

    @Override // com.scanflow.datacapture.core.camera.ScanflowReader.OnLicenseValidationCallback
    public void onLicenseSuccess(String str) {
        n_onLicenseSuccess(str);
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidAddReference(Object obj) {
        if (this.refList == null) {
            this.refList = new ArrayList();
        }
        this.refList.add(obj);
    }

    @Override // crc64f03248cb510113f2.BaseFragment_1, crc64f03248cb510113f2.BaseFragmentWithViewModel, crc64f03248cb510113f2.BaseFragment, mono.android.IGCUserPeer
    public void monodroidClearReferences() {
        ArrayList arrayList = this.refList;
        if (arrayList != null) {
            arrayList.clear();
        }
    }
}
