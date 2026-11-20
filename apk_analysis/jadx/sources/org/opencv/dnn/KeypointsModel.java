package org.opencv.dnn;

/* JADX INFO: loaded from: classes3.dex */
public class KeypointsModel extends Model {
    private static native long KeypointsModel_0(String str, String str2);

    private static native long KeypointsModel_1(String str);

    private static native long KeypointsModel_2(long j);

    private static native void delete(long j);

    private static native long estimate_0(long j, long j2, float f);

    private static native long estimate_1(long j, long j2);

    @Override // org.opencv.dnn.Model
    protected void finalize() {
        delete(this.nativeObj);
    }
}
