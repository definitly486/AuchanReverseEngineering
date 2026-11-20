package androidx.work;

import android.annotation.SuppressLint;
import com.scanflow.datacapture.barinternal.kotlin.collections.ArraysKt;
import com.scanflow.datacapture.barinternal.kotlin.collections.CollectionsKt;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: WorkQuery.kt */
/* JADX INFO: loaded from: classes.dex */
public final class WorkQuery {
    public static final Companion Companion = new Companion(null);
    private final List ids;
    private final List states;
    private final List tags;
    private final List uniqueWorkNames;

    public WorkQuery() {
        this(null, null, null, null, 15, null);
    }

    public static final WorkQuery fromIds(List<UUID> list) {
        return Companion.fromIds(list);
    }

    public static final WorkQuery fromIds(UUID... uuidArr) {
        return Companion.fromIds(uuidArr);
    }

    public static final WorkQuery fromStates(List<? extends WorkInfo.State> list) {
        return Companion.fromStates(list);
    }

    public static final WorkQuery fromStates(WorkInfo.State... stateArr) {
        return Companion.fromStates(stateArr);
    }

    public static final WorkQuery fromTags(List<String> list) {
        return Companion.fromTags(list);
    }

    public static final WorkQuery fromTags(String... strArr) {
        return Companion.fromTags(strArr);
    }

    public static final WorkQuery fromUniqueWorkNames(List<String> list) {
        return Companion.fromUniqueWorkNames(list);
    }

    public static final WorkQuery fromUniqueWorkNames(String... strArr) {
        return Companion.fromUniqueWorkNames(strArr);
    }

    public WorkQuery(List<UUID> ids, List<String> uniqueWorkNames, List<String> tags, List<? extends WorkInfo.State> states) {
        Intrinsics.checkNotNullParameter(ids, "ids");
        Intrinsics.checkNotNullParameter(uniqueWorkNames, "uniqueWorkNames");
        Intrinsics.checkNotNullParameter(tags, "tags");
        Intrinsics.checkNotNullParameter(states, "states");
        this.ids = ids;
        this.uniqueWorkNames = uniqueWorkNames;
        this.tags = tags;
        this.states = states;
    }

    public /* synthetic */ WorkQuery(List list, List list2, List list3, List list4, int i, DefaultConstructorMarker defaultConstructorMarker) {
        this((i & 1) != 0 ? CollectionsKt.emptyList() : list, (i & 2) != 0 ? CollectionsKt.emptyList() : list2, (i & 4) != 0 ? CollectionsKt.emptyList() : list3, (i & 8) != 0 ? CollectionsKt.emptyList() : list4);
    }

    public final List<UUID> getIds() {
        return this.ids;
    }

    public final List<String> getUniqueWorkNames() {
        return this.uniqueWorkNames;
    }

    public final List<String> getTags() {
        return this.tags;
    }

    public final List<WorkInfo.State> getStates() {
        return this.states;
    }

    /* JADX INFO: compiled from: WorkQuery.kt */
    public static final class Builder {
        public static final Companion Companion = new Companion(null);
        private final List ids;
        private final List states;
        private final List tags;
        private final List uniqueWorkNames;

        public /* synthetic */ Builder(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        @SuppressLint({"BuilderSetStyle"})
        public static final Builder fromIds(List<UUID> list) {
            return Companion.fromIds(list);
        }

        @SuppressLint({"BuilderSetStyle"})
        public static final Builder fromStates(List<? extends WorkInfo.State> list) {
            return Companion.fromStates(list);
        }

        @SuppressLint({"BuilderSetStyle"})
        public static final Builder fromTags(List<String> list) {
            return Companion.fromTags(list);
        }

        @SuppressLint({"BuilderSetStyle"})
        public static final Builder fromUniqueWorkNames(List<String> list) {
            return Companion.fromUniqueWorkNames(list);
        }

        private Builder() {
            this.ids = new ArrayList();
            this.uniqueWorkNames = new ArrayList();
            this.tags = new ArrayList();
            this.states = new ArrayList();
        }

        public final Builder addIds(List<UUID> ids) {
            Intrinsics.checkNotNullParameter(ids, "ids");
            CollectionsKt.addAll(this.ids, ids);
            return this;
        }

        public final Builder addUniqueWorkNames(List<String> uniqueWorkNames) {
            Intrinsics.checkNotNullParameter(uniqueWorkNames, "uniqueWorkNames");
            CollectionsKt.addAll(this.uniqueWorkNames, uniqueWorkNames);
            return this;
        }

        public final Builder addTags(List<String> tags) {
            Intrinsics.checkNotNullParameter(tags, "tags");
            CollectionsKt.addAll(this.tags, tags);
            return this;
        }

        public final Builder addStates(List<? extends WorkInfo.State> states) {
            Intrinsics.checkNotNullParameter(states, "states");
            CollectionsKt.addAll(this.states, states);
            return this;
        }

        public final WorkQuery build() {
            if (this.ids.isEmpty() && this.uniqueWorkNames.isEmpty() && this.tags.isEmpty() && this.states.isEmpty()) {
                throw new IllegalArgumentException("Must specify ids, uniqueNames, tags or states when building a WorkQuery");
            }
            return new WorkQuery(this.ids, this.uniqueWorkNames, this.tags, this.states);
        }

        /* JADX INFO: compiled from: WorkQuery.kt */
        public static final class Companion {
            public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
                this();
            }

            private Companion() {
            }

            @SuppressLint({"BuilderSetStyle"})
            public final Builder fromIds(List<UUID> ids) {
                Intrinsics.checkNotNullParameter(ids, "ids");
                Builder builder = new Builder(null);
                builder.addIds(ids);
                return builder;
            }

            @SuppressLint({"BuilderSetStyle"})
            public final Builder fromUniqueWorkNames(List<String> uniqueWorkNames) {
                Intrinsics.checkNotNullParameter(uniqueWorkNames, "uniqueWorkNames");
                Builder builder = new Builder(null);
                builder.addUniqueWorkNames(uniqueWorkNames);
                return builder;
            }

            @SuppressLint({"BuilderSetStyle"})
            public final Builder fromTags(List<String> tags) {
                Intrinsics.checkNotNullParameter(tags, "tags");
                Builder builder = new Builder(null);
                builder.addTags(tags);
                return builder;
            }

            @SuppressLint({"BuilderSetStyle"})
            public final Builder fromStates(List<? extends WorkInfo.State> states) {
                Intrinsics.checkNotNullParameter(states, "states");
                Builder builder = new Builder(null);
                builder.addStates(states);
                return builder;
            }
        }
    }

    /* JADX INFO: compiled from: WorkQuery.kt */
    public static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }

        public final WorkQuery fromIds(List<UUID> ids) {
            Intrinsics.checkNotNullParameter(ids, "ids");
            return new WorkQuery(ids, null, null, null, 14, null);
        }

        public final WorkQuery fromIds(UUID... ids) {
            Intrinsics.checkNotNullParameter(ids, "ids");
            return new WorkQuery(ArraysKt.toList(ids), null, null, null, 14, null);
        }

        public final WorkQuery fromTags(List<String> tags) {
            Intrinsics.checkNotNullParameter(tags, "tags");
            return new WorkQuery(null, null, tags, null, 11, null);
        }

        public final WorkQuery fromTags(String... tags) {
            Intrinsics.checkNotNullParameter(tags, "tags");
            return new WorkQuery(null, null, ArraysKt.toList(tags), null, 11, null);
        }

        public final WorkQuery fromUniqueWorkNames(String... uniqueWorkNames) {
            Intrinsics.checkNotNullParameter(uniqueWorkNames, "uniqueWorkNames");
            return new WorkQuery(null, ArraysKt.toList(uniqueWorkNames), null, null, 13, null);
        }

        public final WorkQuery fromUniqueWorkNames(List<String> uniqueWorkNames) {
            Intrinsics.checkNotNullParameter(uniqueWorkNames, "uniqueWorkNames");
            return new WorkQuery(null, uniqueWorkNames, null, null, 13, null);
        }

        public final WorkQuery fromStates(List<? extends WorkInfo.State> states) {
            Intrinsics.checkNotNullParameter(states, "states");
            return new WorkQuery(null, null, null, states, 7, null);
        }

        public final WorkQuery fromStates(WorkInfo.State... states) {
            Intrinsics.checkNotNullParameter(states, "states");
            return new WorkQuery(null, null, null, ArraysKt.toList(states), 7, null);
        }
    }
}
