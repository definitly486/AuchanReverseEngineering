package com.scanflow.datacapture.barinternal;

import android.view.MotionEvent;
import android.view.View;
import com.scanflow.datacapture.core.camera.ScanflowReader;
import com.scanflow.datacapture.core.camera.manager.BeepManager;
import com.scanflow.datacapture.model.OneOFManyCodesScanResults;
import com.scanflow.ui.ar.ArObject;
import java.util.ArrayList;

/* JADX INFO: loaded from: classes3.dex */
public final class I implements View.OnTouchListener {
    public final /* synthetic */ M a;

    public I(M m) {
        this.a = m;
    }

    @Override // android.view.View.OnTouchListener
    public final boolean onTouch(View view, MotionEvent motionEvent) {
        OneOFManyCodesScanResults decodedResult;
        Integer numValueOf = motionEvent != null ? Integer.valueOf(motionEvent.getAction()) : null;
        if (numValueOf != null && numValueOf.intValue() == 0 && this.a.d) {
            float x = motionEvent.getX();
            float y = motionEvent.getY();
            ArrayList arrayList = this.a.F;
            int size = arrayList.size();
            int i = 0;
            while (true) {
                if (i >= size) {
                    i = -1;
                    break;
                }
                if (((ArObject) arrayList.get(i)).getBoundingBox().contains(x, y)) {
                    break;
                }
                i++;
            }
            if (i >= 0 && (decodedResult = ((ArObject) this.a.F.get(i)).getDecodedResult()) != null) {
                M m = this.a;
                if (m.J.contains(decodedResult)) {
                    m.J.remove(decodedResult);
                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback = m.P;
                    if (onBarcodeScanResultCallback != null) {
                        onBarcodeScanResultCallback.onOneofManyCodeRemoved(decodedResult);
                    }
                } else {
                    BeepManager beepManager = m.K;
                    if (beepManager != null) {
                        beepManager.playBeepSoundAndVibrate();
                    }
                    m.J.add(decodedResult);
                    ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback2 = m.P;
                    if (onBarcodeScanResultCallback2 != null) {
                        onBarcodeScanResultCallback2.onOneofManyCodeSelected(decodedResult);
                    }
                }
                ScanflowReader.OnBarcodeScanResultCallback onBarcodeScanResultCallback3 = m.P;
                if (onBarcodeScanResultCallback3 != null) {
                    onBarcodeScanResultCallback3.onOneOfManyCodeResult(m.J);
                }
            }
        }
        if (view != null) {
            return view.onTouchEvent(motionEvent);
        }
        return false;
    }
}
