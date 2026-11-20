package com.scanflow.datacapture.barinternal.androidx.savedstate.internal;

import android.os.Bundle;
import androidx.lifecycle.Lifecycle;
import androidx.lifecycle.LifecycleEventObserver;
import androidx.lifecycle.LifecycleOwner;
import androidx.savedstate.SavedStateRegistry;
import com.scanflow.datacapture.barinternal.androidx.core.os.BundleKt;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateReader;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateRegistryOwner;
import com.scanflow.datacapture.barinternal.androidx.savedstate.SavedStateWriter;
import com.scanflow.datacapture.barinternal.kotlin.Pair;
import com.scanflow.datacapture.barinternal.kotlin.TuplesKt;
import com.scanflow.datacapture.barinternal.kotlin.Unit;
import com.scanflow.datacapture.barinternal.kotlin.collections.MapsKt;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map;
import kotlin.jvm.functions.Function0;
import kotlin.jvm.internal.DefaultConstructorMarker;
import kotlin.jvm.internal.Intrinsics;

/* JADX INFO: compiled from: SavedStateRegistryImpl.kt */
/* JADX INFO: loaded from: classes.dex */
public final class SavedStateRegistryImpl {
    private static final Companion Companion = new Companion(null);
    private boolean attached;
    private boolean isAllowingSavingState;
    private boolean isRestored;
    private final Map keyToProviders;
    private final SynchronizedObject lock;
    private final Function0 onAttach;
    private final SavedStateRegistryOwner owner;
    private Bundle restoredState;

    public SavedStateRegistryImpl(SavedStateRegistryOwner owner, Function0 onAttach) {
        Intrinsics.checkNotNullParameter(owner, "owner");
        Intrinsics.checkNotNullParameter(onAttach, "onAttach");
        this.owner = owner;
        this.onAttach = onAttach;
        this.lock = new SynchronizedObject();
        this.keyToProviders = new LinkedHashMap();
        this.isAllowingSavingState = true;
    }

    public final boolean isRestored() {
        return this.isRestored;
    }

    public final boolean isAllowingSavingState$savedstate_release() {
        return this.isAllowingSavingState;
    }

    public final Bundle consumeRestoredStateForKey(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        if (!this.isRestored) {
            throw new IllegalStateException("You can 'consumeRestoredStateForKey' only after the corresponding component has moved to the 'CREATED' state");
        }
        Bundle bundle = this.restoredState;
        if (bundle == null) {
            return null;
        }
        Bundle bundleM553constructorimpl = SavedStateReader.m553constructorimpl(bundle);
        Bundle bundleM577getSavedStateimpl = SavedStateReader.m554containsimpl(bundleM553constructorimpl, key) ? SavedStateReader.m577getSavedStateimpl(bundleM553constructorimpl, key) : null;
        SavedStateWriter.m622removeimpl(SavedStateWriter.m591constructorimpl(bundle), key);
        if (SavedStateReader.m587isEmptyimpl(SavedStateReader.m553constructorimpl(bundle))) {
            this.restoredState = null;
        }
        return bundleM577getSavedStateimpl;
    }

    public final void registerSavedStateProvider(String key, SavedStateRegistry.SavedStateProvider provider) {
        Intrinsics.checkNotNullParameter(key, "key");
        Intrinsics.checkNotNullParameter(provider, "provider");
        synchronized (this.lock) {
            if (!this.keyToProviders.containsKey(key)) {
                this.keyToProviders.put(key, provider);
                Unit unit = Unit.INSTANCE;
            } else {
                throw new IllegalArgumentException("SavedStateProvider with the given key is already registered");
            }
        }
    }

    public final SavedStateRegistry.SavedStateProvider getSavedStateProvider(String key) {
        SavedStateRegistry.SavedStateProvider savedStateProvider;
        Intrinsics.checkNotNullParameter(key, "key");
        synchronized (this.lock) {
            Iterator it = this.keyToProviders.entrySet().iterator();
            do {
                savedStateProvider = null;
                if (!it.hasNext()) {
                    break;
                }
                Map.Entry entry = (Map.Entry) it.next();
                String str = (String) entry.getKey();
                SavedStateRegistry.SavedStateProvider savedStateProvider2 = (SavedStateRegistry.SavedStateProvider) entry.getValue();
                if (Intrinsics.areEqual(str, key)) {
                    savedStateProvider = savedStateProvider2;
                }
            } while (savedStateProvider == null);
        }
        return savedStateProvider;
    }

    public final void unregisterSavedStateProvider(String key) {
        Intrinsics.checkNotNullParameter(key, "key");
        synchronized (this.lock) {
        }
    }

    public final void performAttach() {
        if (this.owner.getLifecycle().getCurrentState() != Lifecycle.State.INITIALIZED) {
            throw new IllegalStateException("Restarter must be created only during owner's initialization stage");
        }
        if (this.attached) {
            throw new IllegalStateException("SavedStateRegistry was already attached.");
        }
        this.onAttach.invoke();
        this.owner.getLifecycle().addObserver(new LifecycleEventObserver() { // from class: com.scanflow.datacapture.barinternal.androidx.savedstate.internal.SavedStateRegistryImpl$$ExternalSyntheticLambda0
            @Override // androidx.lifecycle.LifecycleEventObserver
            public final void onStateChanged(LifecycleOwner lifecycleOwner, Lifecycle.Event event) {
                SavedStateRegistryImpl.performAttach$lambda$12(this.f$0, lifecycleOwner, event);
            }
        });
        this.attached = true;
    }

    /* JADX INFO: Access modifiers changed from: private */
    public static final void performAttach$lambda$12(SavedStateRegistryImpl savedStateRegistryImpl, LifecycleOwner lifecycleOwner, Lifecycle.Event event) {
        Intrinsics.checkNotNullParameter(lifecycleOwner, "<unused var>");
        Intrinsics.checkNotNullParameter(event, "event");
        if (event == Lifecycle.Event.ON_START) {
            savedStateRegistryImpl.isAllowingSavingState = true;
        } else if (event == Lifecycle.Event.ON_STOP) {
            savedStateRegistryImpl.isAllowingSavingState = false;
        }
    }

    public final void performRestore$savedstate_release(Bundle bundle) {
        if (!this.attached) {
            performAttach();
        }
        if (this.owner.getLifecycle().getCurrentState().isAtLeast(Lifecycle.State.STARTED)) {
            throw new IllegalStateException(("performRestore cannot be called when owner is " + this.owner.getLifecycle().getCurrentState()).toString());
        }
        if (this.isRestored) {
            throw new IllegalStateException("SavedStateRegistry was already restored.");
        }
        Bundle bundleM577getSavedStateimpl = null;
        if (bundle != null) {
            Bundle bundleM553constructorimpl = SavedStateReader.m553constructorimpl(bundle);
            if (SavedStateReader.m554containsimpl(bundleM553constructorimpl, "androidx.lifecycle.BundlableSavedStateRegistry.key")) {
                bundleM577getSavedStateimpl = SavedStateReader.m577getSavedStateimpl(bundleM553constructorimpl, "androidx.lifecycle.BundlableSavedStateRegistry.key");
            }
        }
        this.restoredState = bundleM577getSavedStateimpl;
        this.isRestored = true;
    }

    /* JADX INFO: compiled from: SavedStateRegistryImpl.kt */
    private static final class Companion {
        public /* synthetic */ Companion(DefaultConstructorMarker defaultConstructorMarker) {
            this();
        }

        private Companion() {
        }
    }

    public final void performSave$savedstate_release(Bundle outBundle) {
        Pair[] pairArr;
        Intrinsics.checkNotNullParameter(outBundle, "outBundle");
        Map mapEmptyMap = MapsKt.emptyMap();
        if (mapEmptyMap.isEmpty()) {
            pairArr = new Pair[0];
        } else {
            ArrayList arrayList = new ArrayList(mapEmptyMap.size());
            for (Map.Entry entry : mapEmptyMap.entrySet()) {
                arrayList.add(TuplesKt.to((String) entry.getKey(), entry.getValue()));
            }
            pairArr = (Pair[]) arrayList.toArray(new Pair[0]);
        }
        Bundle bundleBundleOf = BundleKt.bundleOf((Pair[]) Arrays.copyOf(pairArr, pairArr.length));
        Bundle bundleM591constructorimpl = SavedStateWriter.m591constructorimpl(bundleBundleOf);
        Bundle bundle = this.restoredState;
        if (bundle != null) {
            SavedStateWriter.m592putAllimpl(bundleM591constructorimpl, bundle);
        }
        synchronized (this.lock) {
            try {
                for (Map.Entry entry2 : this.keyToProviders.entrySet()) {
                    SavedStateWriter.m615putSavedStateimpl(bundleM591constructorimpl, (String) entry2.getKey(), ((SavedStateRegistry.SavedStateProvider) entry2.getValue()).saveState());
                }
                Unit unit = Unit.INSTANCE;
            } catch (Throwable th) {
                throw th;
            }
        }
        if (SavedStateReader.m587isEmptyimpl(SavedStateReader.m553constructorimpl(bundleBundleOf))) {
            return;
        }
        SavedStateWriter.m615putSavedStateimpl(SavedStateWriter.m591constructorimpl(outBundle), "androidx.lifecycle.BundlableSavedStateRegistry.key", bundleBundleOf);
    }
}
