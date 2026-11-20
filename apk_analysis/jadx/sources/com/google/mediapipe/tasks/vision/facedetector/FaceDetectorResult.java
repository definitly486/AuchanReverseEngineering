package com.google.mediapipe.tasks.vision.facedetector;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.DetectionProto;
import com.google.mediapipe.tasks.components.containers.Detection;
import com.google.mediapipe.tasks.core.TaskResult;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class FaceDetectorResult implements TaskResult {
    public abstract List<Detection> detections();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    public static FaceDetectorResult create(List<DetectionProto.Detection> list, long j) {
        ArrayList arrayList = new ArrayList();
        Iterator<DetectionProto.Detection> it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(Detection.createFromProto(it.next()));
        }
        return new AutoValue_FaceDetectorResult(j, Collections.unmodifiableList(arrayList));
    }
}
