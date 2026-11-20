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
public abstract class Landmark {
    private static final float TOLERANCE = 1.0E-6f;

    public abstract Optional<Float> presence();

    public abstract Optional<Float> visibility();

    public abstract float x();

    public abstract float y();

    public abstract float z();

    public static Landmark create(float f, float f2, float f3) {
        return new AutoValue_Landmark(f, f2, f3, Optional.empty(), Optional.empty());
    }

    public static Landmark create(float f, float f2, float f3, Optional<Float> optional, Optional<Float> optional2) {
        return new AutoValue_Landmark(f, f2, f3, optional, optional2);
    }

    public static Landmark createFromProto(LandmarkProto.Landmark landmark) {
        Optional optionalEmpty;
        float x = landmark.getX();
        float y = landmark.getY();
        float z = landmark.getZ();
        if (landmark.hasVisibility()) {
            optionalEmpty = Optional.of(Float.valueOf(landmark.getVisibility()));
        } else {
            optionalEmpty = Optional.empty();
        }
        return create(x, y, z, optionalEmpty, landmark.hasPresence() ? Optional.of(Float.valueOf(landmark.getPresence())) : Optional.empty());
    }

    public static List<Landmark> createListFromProto(LandmarkProto.LandmarkList landmarkList) {
        ArrayList arrayList = new ArrayList();
        Iterator<LandmarkProto.Landmark> it = landmarkList.getLandmarkList().iterator();
        while (it.hasNext()) {
            arrayList.add(createFromProto(it.next()));
        }
        return arrayList;
    }

    public final boolean equals(Object obj) {
        if (!(obj instanceof Landmark)) {
            return false;
        }
        Landmark landmark = (Landmark) obj;
        return Math.abs(landmark.x() - x()) < TOLERANCE && Math.abs(landmark.x() - y()) < TOLERANCE && Math.abs(landmark.x() - z()) < TOLERANCE;
    }

    public final int hashCode() {
        return Objects.hash(Float.valueOf(x()), Float.valueOf(y()), Float.valueOf(z()));
    }

    public final String toString() {
        return "<Landmark (x=" + x() + " y=" + y() + " z=" + z() + " visibility= " + visibility() + " presence=" + presence() + ")>";
    }
}
