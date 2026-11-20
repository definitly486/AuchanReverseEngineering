package com.google.mediapipe.tasks.components.containers;

import android.graphics.RectF;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.DetectionProto;
import com.google.mediapipe.formats.proto.LocationDataProto;
import java.util.ArrayList;
import java.util.Collections;
import java.util.List;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
public abstract class Detection {
    private static final int DEFAULT_CATEGORY_INDEX = -1;

    public abstract RectF boundingBox();

    public abstract List<Category> categories();

    public abstract Optional<List<NormalizedKeypoint>> keypoints();

    public static Detection create(List<Category> list, RectF rectF) {
        return new AutoValue_Detection(Collections.unmodifiableList(list), rectF, Optional.empty());
    }

    public static Detection create(List<Category> list, RectF rectF, Optional<List<NormalizedKeypoint>> optional) {
        return new AutoValue_Detection(Collections.unmodifiableList(list), rectF, optional);
    }

    public static Detection createFromProto(DetectionProto.Detection detection) {
        Optional optionalEmpty;
        Optional optionalEmpty2;
        ArrayList arrayList = new ArrayList();
        int i = 0;
        while (i < detection.getScoreCount()) {
            float score = detection.getScore(i);
            int labelId = detection.getLabelIdCount() > i ? detection.getLabelId(i) : -1;
            String displayName = "";
            String label = detection.getLabelCount() > i ? detection.getLabel(i) : "";
            if (detection.getDisplayNameCount() > i) {
                displayName = detection.getDisplayName(i);
            }
            arrayList.add(Category.create(score, labelId, label, displayName));
            i++;
        }
        RectF rectF = new RectF();
        if (detection.getLocationData().hasBoundingBox()) {
            LocationDataProto.LocationData.BoundingBox boundingBox = detection.getLocationData().getBoundingBox();
            rectF.set(boundingBox.getXmin(), boundingBox.getYmin(), boundingBox.getXmin() + boundingBox.getWidth(), boundingBox.getYmin() + boundingBox.getHeight());
        }
        Optional optionalEmpty3 = Optional.empty();
        if (!detection.getLocationData().getRelativeKeypointsList().isEmpty()) {
            optionalEmpty3 = Optional.of(new ArrayList());
            for (LocationDataProto.LocationData.RelativeKeypoint relativeKeypoint : detection.getLocationData().getRelativeKeypointsList()) {
                List list = (List) optionalEmpty3.get();
                float x = relativeKeypoint.getX();
                float y = relativeKeypoint.getY();
                if (relativeKeypoint.hasKeypointLabel()) {
                    optionalEmpty = Optional.of(relativeKeypoint.getKeypointLabel());
                } else {
                    optionalEmpty = Optional.empty();
                }
                if (relativeKeypoint.hasScore()) {
                    optionalEmpty2 = Optional.of(Float.valueOf(relativeKeypoint.getScore()));
                } else {
                    optionalEmpty2 = Optional.empty();
                }
                list.add(NormalizedKeypoint.create(x, y, optionalEmpty, optionalEmpty2));
            }
        }
        return create(arrayList, rectF, optionalEmpty3);
    }
}
