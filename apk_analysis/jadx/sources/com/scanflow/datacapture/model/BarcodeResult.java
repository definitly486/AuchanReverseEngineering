package com.scanflow.datacapture.model;

import com.scanflow.datacapture.barinternal.i.a;
import com.scanflow.datacapture.barinternal.i.b;
import com.scanflow.datacapture.barinternal.i.c;
import com.scanflow.datacapture.barinternal.i.d;
import com.scanflow.datacapture.barinternal.i.e;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: loaded from: classes3.dex */
public final class BarcodeResult {
    private final e ScanResultFailure;
    private final a batchScanResultSuccess;
    private final b oneOfManyCodeResult;
    private final c oneofManyCodeRemoved;
    private final d oneofManyCodeSelected;
    private final ScanResultSuccess scanResultSuccess;

    public BarcodeResult() {
        this(null, null, null, null, null, null, 63, null);
    }

    public static /* synthetic */ BarcodeResult copy$default(BarcodeResult barcodeResult, ScanResultSuccess scanResultSuccess, a aVar, b bVar, d dVar, c cVar, e eVar, int i, Object obj) {
        e eVar2;
        if ((i & 1) != 0) {
            scanResultSuccess = barcodeResult.scanResultSuccess;
        }
        if ((i & 2) != 0) {
            barcodeResult.getClass();
            aVar = null;
        }
        if ((i & 4) != 0) {
            barcodeResult.getClass();
            bVar = null;
        }
        if ((i & 8) != 0) {
            barcodeResult.getClass();
            dVar = null;
        }
        if ((i & 16) != 0) {
            barcodeResult.getClass();
            cVar = null;
        }
        if ((i & 32) != 0) {
            barcodeResult.getClass();
            eVar2 = null;
        } else {
            eVar2 = eVar;
        }
        return barcodeResult.copy(scanResultSuccess, aVar, bVar, dVar, cVar, eVar2);
    }

    public final ScanResultSuccess component1() {
        return this.scanResultSuccess;
    }

    public final a component2() {
        return null;
    }

    public final b component3() {
        return null;
    }

    public final d component4() {
        return null;
    }

    public final c component5() {
        return null;
    }

    public final e component6() {
        return null;
    }

    public final BarcodeResult copy(ScanResultSuccess scanResultSuccess, a aVar, b bVar, d dVar, c cVar, e eVar) {
        return new BarcodeResult(scanResultSuccess, aVar, bVar, dVar, cVar, eVar);
    }

    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        return (obj instanceof BarcodeResult) && Intrinsics.areEqual(this.scanResultSuccess, ((BarcodeResult) obj).scanResultSuccess) && Intrinsics.areEqual((Object) null, (Object) null) && Intrinsics.areEqual((Object) null, (Object) null) && Intrinsics.areEqual((Object) null, (Object) null) && Intrinsics.areEqual((Object) null, (Object) null) && Intrinsics.areEqual((Object) null, (Object) null);
    }

    public final a getBatchScanResultSuccess() {
        return null;
    }

    public final b getOneOfManyCodeResult() {
        return null;
    }

    public final c getOneofManyCodeRemoved() {
        return null;
    }

    public final d getOneofManyCodeSelected() {
        return null;
    }

    public final e getScanResultFailure() {
        return null;
    }

    public final ScanResultSuccess getScanResultSuccess() {
        return this.scanResultSuccess;
    }

    public int hashCode() {
        ScanResultSuccess scanResultSuccess = this.scanResultSuccess;
        return (scanResultSuccess == null ? 0 : scanResultSuccess.hashCode()) * 28629151;
    }

    public String toString() {
        return "BarcodeResult(scanResultSuccess=" + this.scanResultSuccess + ", batchScanResultSuccess=null, oneOfManyCodeResult=null, oneofManyCodeSelected=null, oneofManyCodeRemoved=null, ScanResultFailure=null)";
    }

    public BarcodeResult(ScanResultSuccess scanResultSuccess, a aVar, b bVar, d dVar, c cVar, e eVar) {
        this.scanResultSuccess = scanResultSuccess;
    }

    public /* synthetic */ BarcodeResult(ScanResultSuccess scanResultSuccess, a aVar, b bVar, d dVar, c cVar, e eVar, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? null : scanResultSuccess, (i & 2) != 0 ? null : aVar, (i & 4) != 0 ? null : bVar, (i & 8) != 0 ? null : dVar, (i & 16) != 0 ? null : cVar, (i & 32) != 0 ? null : eVar);
    }
}
