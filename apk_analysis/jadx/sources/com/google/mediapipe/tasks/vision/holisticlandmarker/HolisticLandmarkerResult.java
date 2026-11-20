package com.google.mediapipe.tasks.vision.holisticlandmarker;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.ClassificationProto;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.framework.image.MPImage;
import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import com.google.mediapipe.tasks.core.TaskResult;
import java.util.Collections;
import java.util.List;
import java.util.Optional;
import java.util.function.Function;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class HolisticLandmarkerResult implements TaskResult {
    public abstract Optional<List<Category>> faceBlendshapes();

    public abstract List<NormalizedLandmark> faceLandmarks();

    public abstract List<NormalizedLandmark> leftHandLandmarks();

    public abstract List<Landmark> leftHandWorldLandmarks();

    public abstract List<NormalizedLandmark> poseLandmarks();

    public abstract List<Landmark> poseWorldLandmarks();

    public abstract List<NormalizedLandmark> rightHandLandmarks();

    public abstract List<Landmark> rightHandWorldLandmarks();

    public abstract Optional<MPImage> segmentationMask();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    static HolisticLandmarkerResult create(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList, Optional<ClassificationProto.ClassificationList> optional, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList2, LandmarkProto.LandmarkList landmarkList, Optional<MPImage> optional2, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList3, LandmarkProto.LandmarkList landmarkList2, LandmarkProto.NormalizedLandmarkList normalizedLandmarkList4, LandmarkProto.LandmarkList landmarkList3, long j) {
        List<NormalizedLandmark> listCreateListFromProto = NormalizedLandmark.createListFromProto(normalizedLandmarkList);
        return new AutoValue_HolisticLandmarkerResult(j, Collections.unmodifiableList(listCreateListFromProto), optional.map(new Function() { // from class: com.google.mediapipe.tasks.vision.holisticlandmarker.HolisticLandmarkerResult$$ExternalSyntheticLambda0
            @Override // java.util.function.Function
            public final Object apply(Object obj) {
                return Category.createListFromProto((ClassificationProto.ClassificationList) obj);
            }
        }), Collections.unmodifiableList(NormalizedLandmark.createListFromProto(normalizedLandmarkList2)), Collections.unmodifiableList(Landmark.createListFromProto(landmarkList)), optional2, Collections.unmodifiableList(NormalizedLandmark.createListFromProto(normalizedLandmarkList3)), Collections.unmodifiableList(Landmark.createListFromProto(landmarkList2)), Collections.unmodifiableList(NormalizedLandmark.createListFromProto(normalizedLandmarkList4)), Collections.unmodifiableList(Landmark.createListFromProto(landmarkList3)));
    }

    static HolisticLandmarkerResult createEmpty(long j) {
        List list = Collections.EMPTY_LIST;
        return new AutoValue_HolisticLandmarkerResult(j, list, Optional.empty(), list, list, Optional.empty(), list, list, list, list);
    }
}
