package com.google.mediapipe.tasks.vision.gesturerecognizer;

import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.ClassificationProto;
import com.google.mediapipe.formats.proto.LandmarkProto;
import com.google.mediapipe.tasks.components.containers.Category;
import com.google.mediapipe.tasks.components.containers.Landmark;
import com.google.mediapipe.tasks.components.containers.NormalizedLandmark;
import com.google.mediapipe.tasks.core.TaskResult;
import java.util.ArrayList;
import java.util.Collections;
import java.util.Iterator;
import java.util.List;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class GestureRecognizerResult implements TaskResult {
    private static final int kGestureDefaultIndex = -1;

    public abstract List<List<Category>> gestures();

    public abstract List<List<Category>> handedness();

    public abstract List<List<NormalizedLandmark>> landmarks();

    @Override // com.google.mediapipe.tasks.core.TaskResult
    public abstract long timestampMs();

    public abstract List<List<Landmark>> worldLandmarks();

    static GestureRecognizerResult create(List<LandmarkProto.NormalizedLandmarkList> list, List<LandmarkProto.LandmarkList> list2, List<ClassificationProto.ClassificationList> list3, List<ClassificationProto.ClassificationList> list4, long j) {
        ArrayList arrayList = new ArrayList();
        ArrayList arrayList2 = new ArrayList();
        ArrayList arrayList3 = new ArrayList();
        ArrayList arrayList4 = new ArrayList();
        for (LandmarkProto.NormalizedLandmarkList normalizedLandmarkList : list) {
            ArrayList arrayList5 = new ArrayList();
            arrayList.add(arrayList5);
            for (LandmarkProto.NormalizedLandmark normalizedLandmark : normalizedLandmarkList.getLandmarkList()) {
                arrayList5.add(NormalizedLandmark.create(normalizedLandmark.getX(), normalizedLandmark.getY(), normalizedLandmark.getZ()));
            }
        }
        for (LandmarkProto.LandmarkList landmarkList : list2) {
            ArrayList arrayList6 = new ArrayList();
            arrayList2.add(arrayList6);
            for (LandmarkProto.Landmark landmark : landmarkList.getLandmarkList()) {
                arrayList6.add(Landmark.create(landmark.getX(), landmark.getY(), landmark.getZ()));
            }
        }
        Iterator<ClassificationProto.ClassificationList> it = list3.iterator();
        while (it.hasNext()) {
            arrayList3.add(Collections.unmodifiableList(Category.createListFromProto(it.next())));
        }
        for (ClassificationProto.ClassificationList classificationList : list4) {
            ArrayList arrayList7 = new ArrayList();
            arrayList4.add(arrayList7);
            for (ClassificationProto.Classification classification : classificationList.getClassificationList()) {
                arrayList7.add(Category.create(classification.getScore(), -1, classification.getLabel(), classification.getDisplayName()));
            }
        }
        return new AutoValue_GestureRecognizerResult(j, Collections.unmodifiableList(arrayList), Collections.unmodifiableList(arrayList2), Collections.unmodifiableList(arrayList3), Collections.unmodifiableList(arrayList4));
    }

    @Deprecated
    public List<List<Category>> handednesses() {
        return handedness();
    }
}
