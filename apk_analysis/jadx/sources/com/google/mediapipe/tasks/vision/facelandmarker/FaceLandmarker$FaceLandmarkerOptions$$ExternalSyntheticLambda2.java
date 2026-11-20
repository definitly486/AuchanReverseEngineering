package com.google.mediapipe.tasks.vision.facelandmarker;

import com.google.mediapipe.tasks.vision.facelandmarker.proto.FaceLandmarksDetectorGraphOptionsProto;
import java.util.function.Consumer;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes3.dex */
public final /* synthetic */ class FaceLandmarker$FaceLandmarkerOptions$$ExternalSyntheticLambda2 implements Consumer {
    public final /* synthetic */ FaceLandmarksDetectorGraphOptionsProto.FaceLandmarksDetectorGraphOptions.Builder f$0;

    @Override // java.util.function.Consumer
    public final void accept(Object obj) {
        this.f$0.setMinDetectionConfidence(((Float) obj).floatValue());
    }
}
