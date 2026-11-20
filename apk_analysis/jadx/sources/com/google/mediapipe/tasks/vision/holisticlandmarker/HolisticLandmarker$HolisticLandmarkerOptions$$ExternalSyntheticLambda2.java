package com.google.mediapipe.tasks.vision.holisticlandmarker;

import com.google.mediapipe.tasks.vision.poselandmarker.proto.PoseLandmarksDetectorGraphOptionsProto;
import java.util.function.Consumer;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes3.dex */
public final /* synthetic */ class HolisticLandmarker$HolisticLandmarkerOptions$$ExternalSyntheticLambda2 implements Consumer {
    public final /* synthetic */ PoseLandmarksDetectorGraphOptionsProto.PoseLandmarksDetectorGraphOptions.Builder f$0;

    @Override // java.util.function.Consumer
    public final void accept(Object obj) {
        this.f$0.setMinDetectionConfidence(((Float) obj).floatValue());
    }
}
