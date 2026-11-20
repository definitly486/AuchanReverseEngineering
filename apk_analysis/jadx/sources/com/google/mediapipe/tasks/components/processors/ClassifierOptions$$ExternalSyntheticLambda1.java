package com.google.mediapipe.tasks.components.processors;

import com.google.mediapipe.tasks.components.processors.proto.ClassifierOptionsProto;
import java.util.function.Consumer;

/* JADX INFO: compiled from: R8$$SyntheticClass */
/* JADX INFO: loaded from: classes3.dex */
public final /* synthetic */ class ClassifierOptions$$ExternalSyntheticLambda1 implements Consumer {
    public final /* synthetic */ ClassifierOptionsProto.ClassifierOptions.Builder f$0;

    @Override // java.util.function.Consumer
    public final void accept(Object obj) {
        this.f$0.setMaxResults(((Integer) obj).intValue());
    }
}
