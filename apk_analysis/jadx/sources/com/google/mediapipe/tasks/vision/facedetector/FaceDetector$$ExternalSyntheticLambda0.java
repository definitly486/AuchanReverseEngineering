package com.google.mediapipe.tasks.vision.facedetector;

import com.google.mediapipe.tasks.core.OutputHandler;
import java.util.function.Consumer;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes3.dex */
public final /* synthetic */ class FaceDetector$$ExternalSyntheticLambda0 implements Consumer {
    public final /* synthetic */ OutputHandler f$0;

    @Override // java.util.function.Consumer
    public final void accept(Object obj) {
        this.f$0.setResultListener((OutputHandler.ResultListener) obj);
    }
}
