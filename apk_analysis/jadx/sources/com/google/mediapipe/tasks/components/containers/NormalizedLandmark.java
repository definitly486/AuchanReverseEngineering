package com.google.mediapipe.tasks.components.containers;

import android.annotation.TargetApi;
import com.google.auto.value.AutoValue;
import com.google.mediapipe.formats.proto.LandmarkProto;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

/* JADX INFO: loaded from: classes3.dex */
@AutoValue
@TargetApi(31)
public abstract class NormalizedLandmark {
    private static final float TOLERANCE = 1.0E-6f;

    public abstract Optional<Float> presence();

    public abstract Optional<Float> visibility();

    public abstract float x();

    public abstract float y();

    public abstract float z();

    public static NormalizedLandmark create(float f, float f2, float f3) {
        return new AutoValue_NormalizedLandmark(f, f2, f3, Optional.empty(), Optional.empty());
    }

    public static NormalizedLandmark create(float f, float f2, float f3, Optional<Float> optional, Optional<Float> optional2) {
        return new AutoValue_NormalizedLandmark(f, f2, f3, optional, optional2);
    }

    public static NormalizedLandmark createFromProto(LandmarkProto.NormalizedLandmark normalizedLandmark) {
        Optional optionalEmpty;
        float x = normalizedLandmark.getX();
        float y = normalizedLandmark.getY();
        float z = normalizedLandmark.getZ();
        if (normalizedLandmark.hasVisibility()) {
            optionalEmpty = Optional.of(Float.valueOf(normalizedLandmark.getVisibility()));
        } else {
            optionalEmpty = Optional.empty();
        }
        return create(x, y, z, optionalEmpty, normalizedLandmark.hasPresence() ? Optional.of(Float.valueOf(normalizedLandmark.getPresence())) : Optional.empty());
    }

    public static List<NormalizedLandmark> createListFromProto(LandmarkProto.NormalizedLandmarkList normalizedLandmarkList) {
        ArrayList arrayList = new ArrayList();
        Iterator<LandmarkProto.NormalizedLandmark> it = normalizedLandmarkList.getLandmarkList().iterator();
        while (it.hasNext()) {
            arrayList.add(createFromProto(it.next()));
        }
        return arrayList;
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof NormalizedLandmark)) {
            return false;
        }
        NormalizedLandmark normalizedLandmark = (NormalizedLandmark) obj;
        return Math.abs(normalizedLandmark.x() - x()) < TOLERANCE && Math.abs(normalizedLandmark.x() - y()) < TOLERANCE && Math.abs(normalizedLandmark.x() - z()) < TOLERANCE;
    }

    public final int hashCode() {
        return Objects.hash(Float.valueOf(x()), Float.valueOf(y()), Float.valueOf(z()));
    }

    public final String toString() {
        return "<Normalized Landmark (x=" + x() + " y=" + y() + " z=" + z() + " visibility= " + visibility() + " presence=" + presence() + ")>";
    }
}
