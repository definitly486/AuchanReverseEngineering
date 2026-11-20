package com.scanflow.datacapture.barinternal.androidx.camera.extensions.internal;

import android.hardware.camera2.CaptureRequest;
import androidx.camera.core.impl.Config;
import androidx.camera.core.impl.MutableOptionsBundle;
import androidx.camera.core.impl.OptionsBundle;
import androidx.camera.core.impl.ReadableConfig;

/* JADX INFO: loaded from: classes.dex */
public class RequestOptionConfig implements ReadableConfig {
    private Config mConfig;

    private RequestOptionConfig(Config config) {
        this.mConfig = config;
    }

    @Override // androidx.camera.core.impl.ReadableConfig
    public Config getConfig() {
        return this.mConfig;
    }

    static Config.Option createOptionFromKey(CaptureRequest.Key key) {
        return Config.Option.create("camera2.captureRequest.option." + key.getName(), Object.class, key);
    }

    public static class Builder {
        private MutableOptionsBundle mMutableOptionsBundle = MutableOptionsBundle.create();

        public Builder setCaptureRequestOption(CaptureRequest.Key key, Object obj) {
            this.mMutableOptionsBundle.insertOption(RequestOptionConfig.createOptionFromKey(key), obj);
            return this;
        }

        public RequestOptionConfig build() {
            return new RequestOptionConfig(OptionsBundle.from(this.mMutableOptionsBundle));
        }
    }
}
