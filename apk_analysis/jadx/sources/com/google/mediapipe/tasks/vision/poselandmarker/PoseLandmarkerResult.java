package com.google.mediapipe.tasks.vision.poselandmarker;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import com.google.mediapipe.tasks.core.TaskResult;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class PoseLandmarkerResult implements TaskResult {
    public abstract List<List<NormalizedLandmark>> landmarks();

    public abstract Optional<List<MPImage>> segmentationMasks();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    public abstract List<List<Landmark>> worldLandmarks();

    static PoseLandmarkerResult create(List<LandmarkProto.NormalizedLandmarkList> list, List<LandmarkProto.LandmarkList> list2, Optional<List<MPImage>> optional, long j) {
        Optional optionalEmpty = Optional.empty();
        if (optional.isPresent()) {
            optionalEmpty = Optional.of(Collections.unmodifiableList(optional.get()));
        }
        Optional optional2 = optionalEmpty;
        ArrayList arrayList = new ArrayList();
        Iterator<LandmarkProto.NormalizedLandmarkList> it = list.iterator();
        while (it.hasNext()) {
            arrayList.add(Collections.unmodifiableList(NormalizedLandmark.createListFromProto(it.next())));
        }
        ArrayList arrayList2 = new ArrayList();
        Iterator<LandmarkProto.LandmarkList> it2 = list2.iterator();
        while (it2.hasNext()) {
            arrayList2.add(Collections.unmodifiableList(Landmark.createListFromProto(it2.next())));
        }
        return new AutoValue_PoseLandmarkerResult(j, Collections.unmodifiableList(arrayList), Collections.unmodifiableList(arrayList2), optional2);
    }
}
