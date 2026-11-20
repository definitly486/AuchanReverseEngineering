package com.yandex.mapkit.location;

import com.yandex.runtime.bindings.Archive;
import com.yandex.runtime.bindings.Serializable;

/* JADX INFO: loaded from: classes3.dex */
public final class LocationSettings implements Serializable {
    private Range accuracy;
    private Range headingError;
    private LocationError locationError;
    private TimeInterval locationTimeInterval;
    private boolean provideAccuracy;
    private boolean provideHeading;
    private boolean provideSpeed;
    private boolean provideWheelSpeed;
    private double speed;
    private TimeInterval wheelSpeedTimeInterval;

    public LocationSettings(boolean z, Range range, TimeInterval timeInterval, boolean z2, double d, boolean z3, Range range2, LocationError locationError, boolean z4, TimeInterval timeInterval2) {
        this.provideAccuracy = z;
        this.accuracy = range;
        this.locationTimeInterval = timeInterval;
        this.provideSpeed = z2;
        this.speed = d;
        this.provideHeading = z3;
        this.headingError = range2;
        this.locationError = locationError;
        this.provideWheelSpeed = z4;
        this.wheelSpeedTimeInterval = timeInterval2;
    }

    public LocationSettings() {
        this.provideAccuracy = false;
        this.accuracy = null;
        this.locationTimeInterval = null;
        this.provideSpeed = false;
        this.speed = 0.0d;
        this.provideHeading = false;
        this.headingError = null;
        this.locationError = null;
        this.provideWheelSpeed = false;
        this.wheelSpeedTimeInterval = null;
    }

    public boolean getProvideAccuracy() {
        return this.provideAccuracy;
    }

    public LocationSettings setProvideAccuracy(boolean z) {
        this.provideAccuracy = z;
        return this;
    }

    public Range getAccuracy() {
        return this.accuracy;
    }

    public LocationSettings setAccuracy(Range range) {
        this.accuracy = range;
        return this;
    }

    public TimeInterval getLocationTimeInterval() {
        return this.locationTimeInterval;
    }

    public LocationSettings setLocationTimeInterval(TimeInterval timeInterval) {
        this.locationTimeInterval = timeInterval;
        return this;
    }

    public boolean getProvideSpeed() {
        return this.provideSpeed;
    }

    public LocationSettings setProvideSpeed(boolean z) {
        this.provideSpeed = z;
        return this;
    }

    public double getSpeed() {
        return this.speed;
    }

    public LocationSettings setSpeed(double d) {
        this.speed = d;
        return this;
    }

    public boolean getProvideHeading() {
        return this.provideHeading;
    }

    public LocationSettings setProvideHeading(boolean z) {
        this.provideHeading = z;
        return this;
    }

    public Range getHeadingError() {
        return this.headingError;
    }

    public LocationSettings setHeadingError(Range range) {
        this.headingError = range;
        return this;
    }

    public LocationError getLocationError() {
        return this.locationError;
    }

    public LocationSettings setLocationError(LocationError locationError) {
        this.locationError = locationError;
        return this;
    }

    public boolean getProvideWheelSpeed() {
        return this.provideWheelSpeed;
    }

    public LocationSettings setProvideWheelSpeed(boolean z) {
        this.provideWheelSpeed = z;
        return this;
    }

    public TimeInterval getWheelSpeedTimeInterval() {
        return this.wheelSpeedTimeInterval;
    }

    public LocationSettings setWheelSpeedTimeInterval(TimeInterval timeInterval) {
        this.wheelSpeedTimeInterval = timeInterval;
        return this;
    }

    @Override // com.yandex.runtime.bindings.Serializable
    public void serialize(Archive archive) {
        this.provideAccuracy = archive.add(this.provideAccuracy);
        this.accuracy = (Range) archive.add(this.accuracy, true, (Class<Range>) Range.class);
        this.locationTimeInterval = (TimeInterval) archive.add(this.locationTimeInterval, true, (Class<TimeInterval>) TimeInterval.class);
        this.provideSpeed = archive.add(this.provideSpeed);
        this.speed = archive.add(this.speed);
        this.provideHeading = archive.add(this.provideHeading);
        this.headingError = (Range) archive.add(this.headingError, true, (Class<Range>) Range.class);
        this.locationError = (LocationError) archive.add(this.locationError, true, (Class<LocationError>) LocationError.class);
        this.provideWheelSpeed = archive.add(this.provideWheelSpeed);
        this.wheelSpeedTimeInterval = (TimeInterval) archive.add(this.wheelSpeedTimeInterval, true, (Class<TimeInterval>) TimeInterval.class);
    }
}
