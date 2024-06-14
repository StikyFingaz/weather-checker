<script setup lang="ts">
const city = ref("");
const weatherData = ref(null);
const weatherIcon = ref("");

const fetchWeatherData = async () => {
  try {
    const data = await $fetch(setApiUrl(""), {
      params: { location: city.value },
    });
    weatherData.value = data;
  } catch (error) {
    console.error("Error fetching weather data:", error);
  }
};

watchEffect(() => {
  // console.log(city.value);
  console.log(weatherData.value);
});

onMounted(() => {
  //
});
</script>

<template lang="html">
  <div class="container">
    <h1 class="mt-3 mb-3">Simple Weather Checker with C# ASP.NET API &amp; NuxtJS</h1>
    <h3 class="display-6">Enter city below to check the local weather</h3>
    <div class="card col-12 col-md-3" >
      <div class="card-body">
        <h5 v-if="weatherData" class="card-title">{{ weatherData.name }}, {{ weatherData.country }}</h5>
        <h5 v-else class="card-title">Enter a city</h5>
        <div v-if="weatherData" class="card-text">
          <p>
            <img :src="weatherData.icon" alt="" />
            {{ weatherData.condition }}
          </p>
          <p>
            <div class="">
              Temperature:
            </div>
            <Icon class="text-dark ms-2 fs-1" name="wi:thermometer" />
            {{ weatherData.temperatureC }} °C
          </p>
          <p>
            <div class="">
              Local Time:
            </div>
            <Icon class="text-dark ms-2 fs-1" name="wi:time-1" />
            {{ weatherData.localTime.split(" ")[1] }}
          </p>
        </div>
        <div class="d-flex flex-column mb-3">
          <label for="exampleFormControlInput1" class="form-label">Enter city</label>
          <input
            v-model="city"
            type="text"
            class="form-control"
            id="exampleFormControlInput1"
            placeholder="Zanzibar"
          />
        </div>

        <a @click.prevent="fetchWeatherData" href="#" class="btn btn-primary">Check Weather</a>
      </div>
    </div>
  </div>
</template>

<style lang="css" scoped></style>
